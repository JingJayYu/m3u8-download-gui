using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1102065_Final_v2
{
    internal class M3U8
    {
        static string settingInJsonPath = "./Setting/settings.json";
        string tsSavePath = "./.ts";
        string tsDownloadPath;

        Form1 f1;
        string M3U8_URL;
        string SavePath;
        string SaveFormat;
        DateTime StartTime;

        string UserAgent;
        string Referer;
        bool isAnyFail = false;

        public M3U8(Form1 f1, DateTime StartTime)
        {
            this.f1 = f1;
            this.M3U8_URL = f1.URL;
            this.SavePath = f1.SavePath;
            this.SaveFormat = f1.Format;
            this.StartTime = StartTime;
            initial();
        }
        private void initial()
        {
            f1.Add_Log_rtx("Initialing");
            string jsonContent = File.ReadAllText(settingInJsonPath);
            JObject settings = JObject.Parse(jsonContent);
            UserAgent = settings["M3U8"]["User-Agent"].ToString();
            f1.Add_Log_rtx("Set UserAgent to " + UserAgent);
            Referer = SetReferer(settings);

            if (!Directory.Exists(tsSavePath))
            {
                Directory.CreateDirectory(tsSavePath);
            }
            tsDownloadPath = Path.Combine(tsSavePath, StartTime.ToString("yyyyMMdd_HHmmss"));
            Directory.CreateDirectory(tsDownloadPath);
            
        }

        private string setFillZero(int n)
        {
            int count = 1;
            while(n != 0)
            {
                n /= 10;
                count++;
            }
            string zero = "";
            while(count > 0)
            {
                count--;
                zero += "0";
            }
            return zero;

        }

        internal async Task RunAsync()
        {
            try
            {
                f1.Add_Log_rtx("Program Start");
                List<Task> tasks = new List<Task>();
                List<string> ts_list = new List<string>();

                tasks.Add(Task.Run(() => { ts_list = Parse(M3U8_URL); }));
                await Task.WhenAll(tasks.ToArray());

                tasks.Add(Task.Run(() => UpdateProgressBar(ts_list.Count)));

                string setfill = setFillZero(ts_list.Count);
                foreach (string ts in ts_list)
                {
                    f1.setStatus_lbl("Downloading", Color.Green);
                    tasks.Add(Task.Run(() => Download(ts, tsDownloadPath, M3U8_URL, ts_list.IndexOf(ts).ToString(setfill))));
                }
                await Task.WhenAll(tasks.ToArray());

                tasks.Add(Task.Run(() => Merge(ts_list.Count)));
                await Task.WhenAll(tasks.ToArray());
            }
            catch (WebException ex)
            {
                f1.setStatus_lbl("Download Fail", Color.Red);
                f1.Add_Log_rtx("Something fail " + ex.Message);
            }
            catch (IOException ex)
            {
                f1.setStatus_lbl("Download Fail", Color.Red);
                f1.Add_Log_rtx("Something fail " + ex.Message);
            }
            catch (Exception ex)
            {
                f1.setStatus_lbl("Download Fail", Color.Red);
                f1.Add_Log_rtx("Something fail " + ex.Message);
            }
            finally 
            {
                Delete_tsFolder();
            }
        }

        private string SetReferer(JObject settings)
        {
            JArray ReferersInJson = (JArray)settings["M3U8"]["Referers"];
            foreach (JObject data in ReferersInJson)
            {
                if (M3U8_URL.Contains(data["Website"].ToString()))
                {
                    f1.Add_Log_rtx("Set Referer to " + data["Referer"].ToString());
                    return data["Referer"].ToString();
                }
            }
            f1.Add_Log_rtx("Set Referer to Empty");
            return "";
        }

        private List<string> Parse(string url)
        {
            try
            {
                f1.Add_Log_rtx("Parsing with " + url);
                List<string> container = new List<string>();
                using (HttpWebResponse response = Request(url))
                {
                    string[] content = new StreamReader(response.GetResponseStream(), true).ReadToEnd().Split('\n');
                    foreach (string ts in content)
                    {
                        if (ts.Contains(".ts")) container.Add(ts);
                    }
                    f1.Add_Log_rtx("Parsing " + url + " Sucess");
                    return container;
                }
            }
            catch (WebException ex)
            {
                throw (ex);
            }
            catch (IOException ex)
            {
                throw (ex);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private HttpWebResponse Request(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.UserAgent = UserAgent;
                request.Referer = Referer;

                request.Method = "GET";
                request.Timeout = 60 * 1000;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                f1.Add_Log_rtx("Requesting from " + url + " " + response.StatusCode);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(response.StatusCode.ToString());
                }
                else
                {
                    return response;
                }
            }
            catch (WebException ex)
            {
                f1.Add_Log_rtx("Requesting fail from " + url + " " + ex.Message + " Try again or Replace a M3U8 source");
                throw (ex);
            }
            catch (IOException ex)
            {
                f1.Add_Log_rtx("Requesting fail from " + url + " " + ex.Message + " Try again or Replace a M3U8 source");
                throw (ex);
            }
            catch (Exception ex)
            {
                f1.Add_Log_rtx("Requesting fail from " + url + " " + ex.Message + " Try again or Replace a M3U8 source");
                throw (ex);
            }

        }

        private string GetBaseURL(string url)
        {
            string[] segments = url.Split('/');

            string baseUrl = string.Join("/", segments, 0, segments.Length - 1);

            return baseUrl;
        }

        private void Download(string ts_url, string download_path, string M3U8_URL, string sort)
        {
            string debrisName = $"{download_path}/{sort}.ts";
            if (!ts_url.StartsWith("http"))
            {
                string baseURL = GetBaseURL(M3U8_URL);
                ts_url = baseURL + '/' + ts_url;
            }

            if (!File.Exists(debrisName) && !this.isAnyFail)
            {
                try
                {
                    using (HttpWebResponse response = Request(ts_url)) 
                    {
                        f1.Add_Log_rtx("Start Downloading " + ts_url);
                        using (FileStream fileStream = new FileStream(debrisName, FileMode.Create))
                        using (BinaryReader reader = new BinaryReader(response.GetResponseStream()))
                        using (BinaryWriter writer = new BinaryWriter(fileStream))
                        {
                            bool isFileEmpty = false;
                            while (!isFileEmpty)
                            {
                                try
                                {
                                    writer.Write(reader.ReadByte());

                                }
                                catch { isFileEmpty = true; }
                            }
                        }
                    }
                }
                catch (WebException ex)
                {
                    f1.Add_Log_rtx($"Donwload {ts_url} fail: {ex.Message}");
                    this.isAnyFail = true;
                    throw (ex);
                }
                catch (IOException ex)
                {
                    f1.Add_Log_rtx($"Donwload {ts_url} fail: {ex.Message}");
                    this.isAnyFail = true;
                    throw (ex);
                }
                catch (Exception ex)
                {
                    f1.Add_Log_rtx($"Donwload {ts_url} fail: {ex.Message}");
                    this.isAnyFail = true;
                    throw (ex);
                }
            }
        }

        private async void UpdateProgressBar(int total)
        {
            int fCount = 0;
            while (fCount < total)
            {
                await Task.Delay(500);
                fCount = Directory.GetFiles(tsDownloadPath, "*", SearchOption.TopDirectoryOnly).Length;
                f1.setProgressBar(fCount, total);
                if (this.isAnyFail)
                {
                    break;
                }
            }
        }

        private void tsConvert(string tsPath)
        {
            f1.setStatus_lbl("Starting Convert", Color.Green);
            f1.Add_Log_rtx("Starting Convert");
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "./ffmpeg/bin/ffmpeg.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;

            string ConvertSavePath = $"{this.SavePath}/{this.StartTime.ToString("yyyyMMdd_HHmmss")}.{this.SaveFormat}";
            startInfo.Arguments = $"-i {tsPath} -map 0 -c copy {ConvertSavePath}";

            using (Process exeProcess = Process.Start(startInfo))
            {
                string error = exeProcess.StandardError.ReadToEnd();
                exeProcess.WaitForExit();

                f1.Add_Log_rtx(error);
            }
            
            File.Delete(tsPath);

            if (File.Exists(ConvertSavePath))
            {
                f1.setStatus_lbl("Convert Success", Color.Green);
                f1.Add_Log_rtx("Convert Success");
            }
            else
            {
                f1.setStatus_lbl("Convert Fail", Color.Red);
                f1.Add_Log_rtx("Convert Fail, check whether the m3u8 url is encrypt?");
            }
        }

        private void Merge(int total)
        {
            string[] files = Directory.GetFiles(tsDownloadPath, "*", SearchOption.TopDirectoryOnly);
            if (files.Length >= total)
            {
                f1.Add_Log_rtx("All files are downloaded, Start merge files");
                string tsPath = $"{this.SavePath}/{StartTime.ToString("yyyyMMdd_HHmmss")}.ts";
                using (FileStream fsStream = new FileStream(tsPath, FileMode.Create))
                using (BinaryWriter writer = new BinaryWriter(fsStream))
                foreach (string file in files)
                {
                    using (FileStream fileStream = new FileStream(file, FileMode.Open)) 
                    using(BinaryReader reader = new BinaryReader(fileStream))
                    {
                        bool isFileEmpty = false;
                        while (!isFileEmpty)
                        {
                            try
                            {
                                writer.Write(reader.ReadByte());

                            }
                            catch { isFileEmpty = true; }
                        }
                    }
                }
                f1.setStatus_lbl("Merge Success", Color.Green);
                f1.Add_Log_rtx("Merge files Success!");
                tsConvert(tsPath);
            }
            else
            {
                f1.setStatus_lbl("Merge Fail", Color.Red);
                f1.Add_Log_rtx("File is missing, Merge fail.");
            }
        }

        private void Delete_tsFolder()
        {
            f1.Add_Log_rtx("Deleting all .ts files from tmp folder");
            DirectoryInfo dir = new DirectoryInfo(tsDownloadPath);
            dir.Delete(true);
            f1.Add_Log_rtx("All .ts files are deleted");
        }
    }
}
