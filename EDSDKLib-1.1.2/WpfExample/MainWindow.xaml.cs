using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EOSDigital.API;
using EOSDigital.SDK;
using System.Timers;
using System.Threading;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        #region Variables

        CanonAPI APIHandler;
        Camera MainCamera;
        CameraValue[] AvList;
        CameraValue[] TvList;
        CameraValue[] ISOList;
        List<Camera> CamList;
        bool IsInit = false;
        int BulbTime = 30;
        ImageBrush bgbrush = new ImageBrush();
        Action<BitmapImage> SetImageAction;
        System.Windows.Forms.FolderBrowserDialog SaveFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();

        int ErrCount;
        object ErrLock = new object();

        int Near1Ticks = 0;
        int Near2Ticks = 0;
        int Near3Ticks = 0;
        int Far1Ticks = 0;
        int Far2Ticks = 0;
        int Far3Ticks = 0;
        int FocusPosition = 0;
        int CurrentFocusPosition = 0;
        int FocusTimerTicks = 0;
        int FocusTimerTicksCount = 0;
        int PhotoFreqence = 0;
        int PhotoCount = 0;
        int PhotoTaken = 0;


        Boolean TakePicture = false;

        System.Timers.Timer aTimer;
        System.Timers.Timer bTimer;


        #endregion

        public MainWindow()
        {
            try
            {
                InitializeComponent();
                APIHandler = new CanonAPI();
                APIHandler.CameraAdded += APIHandler_CameraAdded;
                ErrorHandler.SevereErrorHappened += ErrorHandler_SevereErrorHappened;
                ErrorHandler.NonSevereErrorHappened += ErrorHandler_NonSevereErrorHappened;
                SavePathTextBox.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "RemotePhoto");
                SetImageAction = (BitmapImage img) => { bgbrush.ImageSource = img; };
                SaveFolderBrowser.Description = "Save Images To...";
                RefreshCamera();
                IsInit = true;

                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnaTimedEvent);
                aTimer.Interval = 100;
                aTimer.Enabled = true;

                bTimer = new System.Timers.Timer();
                bTimer.Elapsed += new ElapsedEventHandler(OnbTimedEvent);
                bTimer.Interval = 1000;
                bTimer.Enabled = true;

            }
            catch (DllNotFoundException) { ReportError("Canon DLLs not found!", true); }
            catch (Exception ex) { ReportError(ex.Message, true); }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                IsInit = false;
                MainCamera?.Dispose();
                APIHandler?.Dispose();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #region API Events

        private void APIHandler_CameraAdded(CanonAPI sender)
        {
            try { Dispatcher.Invoke((Action)delegate { RefreshCamera(); }); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_StateChanged(Camera sender, StateEventID eventID, int parameter)
        {
            try { if (eventID == StateEventID.Shutdown && IsInit) { Dispatcher.Invoke((Action)delegate { CloseSession(); }); } }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_ProgressChanged(object sender, int progress)
        {
            try { MainProgressBar.Dispatcher.Invoke((Action)delegate { MainProgressBar.Value = progress; }); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_LiveViewUpdated(Camera sender, Stream img)
        {
            try
            {
                using (WrapStream s = new WrapStream(img))
                {
                    img.Position = 0;
                    BitmapImage EvfImage = new BitmapImage();
                    EvfImage.BeginInit();
                    EvfImage.StreamSource = s;
                    EvfImage.CacheOption = BitmapCacheOption.OnLoad;
                    EvfImage.EndInit();
                    EvfImage.Freeze();
                    Application.Current.Dispatcher.BeginInvoke(SetImageAction, EvfImage);
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_DownloadReady(Camera sender, DownloadInfo Info)
        {
            try
            {
                string dir = null;
                SavePathTextBox.Dispatcher.Invoke((Action)delegate { dir = SavePathTextBox.Text; });
                sender.DownloadFile(Info, dir);
                MainProgressBar.Dispatcher.Invoke((Action)delegate { MainProgressBar.Value = 0; });
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void ErrorHandler_NonSevereErrorHappened(object sender, ErrorCode ex)
        {
            ReportError($"SDK Error code: {ex} ({((int)ex).ToString("X")})", false);
        }

        private void ErrorHandler_SevereErrorHappened(object sender, Exception ex)
        {
            ReportError(ex.Message, true);
        }

        #endregion

        #region Session

        private void OpenSessionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MainCamera?.SessionOpen == true) CloseSession();
                else OpenSession();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            try { RefreshCamera(); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Settings

        private void AvCoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (AvCoBox.SelectedIndex < 0) return;
                MainCamera.SetSetting(PropertyID.Av, AvValues.GetValue((string)AvCoBox.SelectedItem).IntValue);
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void TvCoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (TvCoBox.SelectedIndex < 0) return;

                MainCamera.SetSetting(PropertyID.Tv, TvValues.GetValue((string)TvCoBox.SelectedItem).IntValue);
                if ((string)TvCoBox.SelectedItem == "Bulb")
                {
                    BulbBox.IsEnabled = true;
                    BulbSlider.IsEnabled = true;
                }
                else
                {
                    BulbBox.IsEnabled = false;
                    BulbSlider.IsEnabled = false;
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void ISOCoBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (ISOCoBox.SelectedIndex < 0) return;
                MainCamera.SetSetting(PropertyID.ISO, ISOValues.GetValue((string)ISOCoBox.SelectedItem).IntValue);
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void TakePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            bTimer.Stop();
            bTimer.Interval = Convert.ToInt16(PhotoFreq.Text);
            bTimer.Start();
            bTimer.Enabled = true;
            PhotoCount = Convert.ToInt16(PhotoCnt.Text);
            PhotoTaken = 0;
        }

        private void VideoButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Recording state = (Recording)MainCamera.GetInt32Setting(PropertyID.Record);
                if (state != Recording.On)
                {
                    MainCamera.StartFilming(true);
                    VideoButtonText.Inlines.Clear();
                    VideoButtonText.Inlines.Add("Stop");
                    VideoButtonText.Inlines.Add(new LineBreak());
                    VideoButtonText.Inlines.Add("Video");
                }
                else
                {
                    bool save = (bool)STComputerRdButton.IsChecked || (bool)STBothRdButton.IsChecked;
                    MainCamera.StopFilming(save);
                    VideoButtonText.Inlines.Clear();
                    VideoButtonText.Inlines.Add("Record");
                    VideoButtonText.Inlines.Add(new LineBreak());
                    VideoButtonText.Inlines.Add("Video");
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void BulbSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            try { if (IsInit) BulbBox.Text = BulbSlider.Value.ToString(); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void BulbBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (IsInit)
                {
                    int b;
                    if (int.TryParse(BulbBox.Text, out b) && b != BulbTime)
                    {
                        BulbTime = b;
                        BulbSlider.Value = BulbTime;
                    }
                    else BulbBox.Text = BulbTime.ToString();
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void SaveToRdButton_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (IsInit)
                {
                    if ((bool)STCameraRdButton.IsChecked)
                    {
                        MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Camera);
                        BrowseButton.IsEnabled = false;
                        SavePathTextBox.IsEnabled = false;
                    }
                    else
                    {
                        if ((bool)STComputerRdButton.IsChecked) MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);
                        else if ((bool)STBothRdButton.IsChecked) MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Both);

                        MainCamera.SetCapacity(4096, int.MaxValue);
                        BrowseButton.IsEnabled = true;
                        SavePathTextBox.IsEnabled = true;
                    }
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Directory.Exists(SavePathTextBox.Text)) SaveFolderBrowser.SelectedPath = SavePathTextBox.Text;
                if (SaveFolderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SavePathTextBox.Text = SaveFolderBrowser.SelectedPath;
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Live view

        private void StarLVButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!MainCamera.IsLiveViewOn)
                {
                    LVCanvas.Background = bgbrush;
                    MainCamera.StartLiveView();
                    StarLVButton.Content = "Stop LV";
                    aTimer.Enabled = true;
                    ResetLensToMinimum();
                               }
                else
                {
                    MainCamera.StopLiveView();
                    StarLVButton.Content = "Start LV";
                    LVCanvas.Background = Brushes.LightGray;
                    aTimer.Enabled = false;
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusNear3Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near3);
                Near3Ticks += 1;
                Far3Ticks -= 1;
                DisplayTicks();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusNear2Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near2);
                Near2Ticks += 1;
                Far2Ticks -= 1;
                DisplayTicks();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusNear1Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near1);
                Near1Ticks += 1;
                Far1Ticks -= 1;
                DisplayTicks();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusFar1Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far1);
                Near1Ticks -= 1;
                Far1Ticks += 1;
                DisplayTicks();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusFar2Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far2);
                Near2Ticks -= 1;
                Far2Ticks += 1;
                DisplayTicks();

            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusFar3Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far3);
                Near3Ticks -= 1;
                Far3Ticks += 1;
                DisplayTicks();

            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Subroutines

        private void CloseSession()
        {
            MainCamera.CloseSession();
            AvCoBox.Items.Clear();
            TvCoBox.Items.Clear();
            ISOCoBox.Items.Clear();
            SettingsGroupBox.IsEnabled = false;
            LiveViewGroupBox.IsEnabled = false;
            SessionButton.Content = "Open Session";
            SessionLabel.Content = "No open session";
            StarLVButton.Content = "Start LV";
        }

        private void RefreshCamera()
        {
            CameraListBox.Items.Clear();
            CamList = APIHandler.GetCameraList();
            foreach (Camera cam in CamList) CameraListBox.Items.Add(cam.DeviceName);
            if (MainCamera?.SessionOpen == true) CameraListBox.SelectedIndex = CamList.FindIndex(t => t.ID == MainCamera.ID);
            else if (CamList.Count > 0) CameraListBox.SelectedIndex = 0;
        }

        private void OpenSession()
        {
            if (CameraListBox.SelectedIndex >= 0)
            {
                MainCamera = CamList[CameraListBox.SelectedIndex];
                MainCamera.OpenSession();
                MainCamera.LiveViewUpdated += MainCamera_LiveViewUpdated;
                MainCamera.ProgressChanged += MainCamera_ProgressChanged;
                MainCamera.StateChanged += MainCamera_StateChanged;
                MainCamera.DownloadReady += MainCamera_DownloadReady;

                SessionButton.Content = "Close Session";
                SessionLabel.Content = MainCamera.DeviceName;
                AvList = MainCamera.GetSettingsList(PropertyID.Av);
                TvList = MainCamera.GetSettingsList(PropertyID.Tv);
                ISOList = MainCamera.GetSettingsList(PropertyID.ISO);
                foreach (var Av in AvList) AvCoBox.Items.Add(Av.StringValue);
                foreach (var Tv in TvList) TvCoBox.Items.Add(Tv.StringValue);
                foreach (var ISO in ISOList) ISOCoBox.Items.Add(ISO.StringValue);
                AvCoBox.SelectedIndex = AvCoBox.Items.IndexOf(AvValues.GetValue(MainCamera.GetInt32Setting(PropertyID.Av)).StringValue);
                TvCoBox.SelectedIndex = TvCoBox.Items.IndexOf(TvValues.GetValue(MainCamera.GetInt32Setting(PropertyID.Tv)).StringValue);
                ISOCoBox.SelectedIndex = ISOCoBox.Items.IndexOf(ISOValues.GetValue(MainCamera.GetInt32Setting(PropertyID.ISO)).StringValue);
                SettingsGroupBox.IsEnabled = true;
                LiveViewGroupBox.IsEnabled = true;
            }
        }

        private void ReportError(string message, bool lockdown)
        {
            int errc;
            lock (ErrLock) { errc = ++ErrCount; }

            if (lockdown) EnableUI(false);

            if (errc < 4) MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (errc == 4) MessageBox.Show("Many errors happened!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            lock (ErrLock) { ErrCount--; }
        }

        private void EnableUI(bool enable)
        {
            if (!Dispatcher.CheckAccess()) Dispatcher.Invoke((Action)delegate { EnableUI(enable); });
            else
            {
                SettingsGroupBox.IsEnabled = enable;
                InitGroupBox.IsEnabled = enable;
                LiveViewGroupBox.IsEnabled = enable;
            }
        }

        #endregion

        private void textNear3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textNear2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textNear1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textFar1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textFar2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textFar3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DisplayTicks()
        {
            textNear1.Text = Near1Ticks.ToString();
            textNear2.Text = Near2Ticks.ToString();
            textNear3.Text = Near3Ticks.ToString();

            textFar1.Text = Far1Ticks.ToString();
            textFar2.Text = Far2Ticks.ToString();
            textFar3.Text = Far3Ticks.ToString();
        }
        private void ResetLensToMinimum()
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long milliWait = 70;
            long milliExec = 3000;
            int loopCount = 1;

            while ( (milliseconds + milliExec) > (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) )  
            {
                if ((milliseconds + milliWait*loopCount) < (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond))
                {
                    
                    MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near3);
                    loopCount += 1;
                    Console.WriteLine(loopCount.ToString());

                }
            }

            milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            milliWait = 70;
            milliExec = 1000;
            loopCount = 1;
            while ((milliseconds + milliExec) > (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond))
            {
                if ((milliseconds + milliWait * loopCount) > (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond))
                {

                    MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near1);
                    loopCount += 1;
                    Console.WriteLine(loopCount.ToString());

                }
            }



            FocusPosition = 0;
            CurrentFocusPosition = 0;
            //SetFocusDistance400();

            //SetFocusDistance(400);
            //SetFocusDistance(200);
            //SetFocusDistance(300);




        }

        private void SetFocusDistance400()
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long milliWait = 100;   //Waittime to step one Focus tick.
            long milliExec = 4000; //Default

            int loopCount = 1;     //TickCounter
            int ThreeTicks = 13;
            int OneTicks = 31;
            int pass = 0;


            int nCount = 0;
            Thread.Sleep(100);
            while (nCount < ThreeTicks)
            {
                MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far3);
                Thread.Sleep(100);
                nCount++;
                Console.WriteLine("Far3 Ticks: " + nCount.ToString() + " of Total: " + ThreeTicks.ToString());
            }
            nCount = 0;
            while (nCount < OneTicks)
            {
                MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near1);
                Thread.Sleep(100);
                nCount++;
                Console.WriteLine("Far1 Ticks: " + nCount.ToString() + " of Total: " + OneTicks.ToString());
            }

/*

            while ((milliseconds + milliExec) > (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) )
            {
                if ( ((milliseconds + (milliWait * loopCount)) < (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond)) && (loopCount < ThreeTicks) && pass == 0)
                {
                    MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far3);
                    Console.WriteLine("Far3 Ticks: " + loopCount.ToString() + " of Total: " + ThreeTicks.ToString() + " Tick: " + Convert.ToString( DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond));
                    loopCount += 1;
                                      
                }

                if ( ((milliseconds + (milliWait * loopCount)) < (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond)) && (loopCount < ThreeTicks + OneTicks) && pass == 1)
                {
                    MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far1);
                    Console.WriteLine("Far1 Ticks: " + loopCount.ToString() + " of Total: " + OneTicks.ToString());
                    loopCount += 1;

                }
                if (loopCount == ThreeTicks) { pass = 1; }
                                
            }

    */
            Console.WriteLine("Elapsed Time: " + Convert.ToString(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - milliseconds));
            FocusPosition = 1352;
            FocusTimerTicks = 1352;
            CurrentFocusPosition = 1352;
            Console.WriteLine("Focus Position set to: " + Convert.ToString(FocusPosition) );
        }

        private void SetFocusDistanceTimer(int FocusDistance)
        {
            aTimer.Stop();
            aTimer.Interval = 70;
            aTimer.Start();

            FocusPosition = CurrentFocusPosition;
            if (FocusDistance == 0) { return; }

            FocusTimerTicks = Convert.ToInt16( (903 * Math.Log(FocusDistance) - 4000 ));
            //FocusTimerTicks = Convert.ToInt16( (4000 - 2.4E+05 / FocusDistance) -1176);
            FocusTimerTicks = Convert.ToInt16( 1713.77551373 - 1.45669321E+05 / FocusDistance);

            //if (FocusTimerTicks == 0) { ResetLensToMinimum(); return; }
            if (FocusPosition > FocusTimerTicks) { FocusTimerTicks = FocusTimerTicks - FocusPosition; }
            if (FocusPosition < FocusTimerTicks) { FocusTimerTicks = FocusTimerTicks - FocusPosition; }
            if (FocusPosition == FocusTimerTicks) { return; }

            FocusPosition = FocusPosition + FocusTimerTicks;
            FocusTimerTicks = Math.Abs(FocusTimerTicks);
            

        }


        private void SetFocusTicks(int FocusTicks)
        {
            long milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long milliWait = 20;   //Waittime to step one Focus tick.
            long milliExec = 1000; //Default
            int loopCount = 1;     //TickCounter
    
            int CurrentFocusPosition = FocusPosition;

            int Travel = 0; //Debug only

            if (FocusPosition == FocusTicks) { return; }
            if (FocusTicks == 0) { ResetLensToMinimum(); return; }

            if (FocusPosition > FocusTicks) { FocusTicks = FocusTicks - FocusPosition; }
            if (FocusPosition < FocusTicks) { FocusTicks = FocusTicks - FocusPosition; }
            
            

            FocusPosition = FocusPosition + FocusTicks;
            FocusTicks = Math.Abs(FocusTicks);
            Travel = Math.Abs(CurrentFocusPosition - FocusPosition); //Debug only
            milliExec = FocusTicks * milliWait; //Calculate TimerLoop

            while ((milliseconds + milliExec) > (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) && (loopCount <= FocusTicks))
            {
                if ((milliseconds + (milliWait * loopCount)) > (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond))
                {
                    if (CurrentFocusPosition < FocusPosition) { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far1); }
                    if (CurrentFocusPosition > FocusPosition) { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near1); }


                    //Console.Write(loopCount.ToString());
                    Console.WriteLine("TravelPos: " + loopCount.ToString() + " TravelTarget: " + Travel.ToString() + " New abs Position: " + FocusPosition.ToString());

                    loopCount += 1;

                }
            }

            Console.WriteLine("Elapsed Time: " + Convert.ToString(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - milliseconds) );

        

        }

        private void SetFocusTicksTimer(int FocusTicks)
        {

            aTimer.Stop();
            aTimer.Interval = 70;
            aTimer.Start();

            FocusPosition = CurrentFocusPosition;
            if (FocusTicks == 0) { ResetLensToMinimum(); return; }
            FocusTimerTicks = FocusTicks;

            //if (FocusTimerTicks == 0) { ResetLensToMinimum(); return; }
            if (FocusPosition > FocusTimerTicks) { FocusTimerTicks = FocusTimerTicks - FocusPosition; }
            if (FocusPosition < FocusTimerTicks) { FocusTimerTicks = FocusTimerTicks - FocusPosition; }
            if (FocusPosition == FocusTimerTicks) { return; }

            FocusPosition = FocusPosition + FocusTimerTicks;
            FocusTimerTicks = Math.Abs(FocusTimerTicks);

        }


        private void ClearTicks_Click(object sender, RoutedEventArgs e)
        {

            Near1Ticks = 0;
            Near2Ticks = 0;
            Near3Ticks = 0;

            Far1Ticks = 0;
            Far2Ticks = 0;
            Far3Ticks = 0;
            DisplayTicks();
        }

        private void FocusDistance_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SetFocus_Click(object sender, RoutedEventArgs e)
        {
            SetFocusDistanceTimer( Convert.ToInt16(FocusDistance.Text.ToString()) );

        }

        private void SetTicks_Click(object sender, RoutedEventArgs e)
        {
            SetFocusTicksTimer(Convert.ToInt16(FocusTicks.Text.ToString()));

        }

        // Specify what you want to happen when the Elapsed event is raised.
        private void OnaTimedEvent(object source, ElapsedEventArgs e)
        {
            //Console.Write(".");
            if (FocusPosition == CurrentFocusPosition) { return; }
            if (CurrentFocusPosition < FocusPosition) { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Far1); CurrentFocusPosition += 1; }
            if (CurrentFocusPosition > FocusPosition) { MainCamera.SendCommand(CameraCommand.DriveLensEvf, (int)DriveLens.Near1); CurrentFocusPosition -= 1; }
            //Console.Write(loopCount.ToString());
            Console.WriteLine("TravelPos: " + CurrentFocusPosition.ToString() + " TravelTarget: " + FocusPosition.ToString() );
        }

        private void OnbTimedEvent(object source, ElapsedEventArgs e)
        {
            if (PhotoCount == PhotoTaken) { return; }
           
            try
            {
             MainCamera.TakePhotoAsync();
             PhotoTaken += 1;
             Console.WriteLine("Photo: " + PhotoTaken.ToString() + " of total: " + PhotoCount.ToString());
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void FocusTicks_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
;
