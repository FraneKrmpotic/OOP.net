using DataLayer.Models;
using DataLayer.Constants;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Repository
    {
        public const string HR = "hr-HR", EN = "en";
        public static string SETTINGS_PATH = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Settings/settings.txt");
        public static string FAVOURITES_PATH = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Settings/favourites.txt");
        public const string DEFAULT_SETTINGS = "Croatian|True|";
        private const char DEL = '|';

        //spremanje settings-a u file
        public static void SaveSettings()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder
                .Append(FileSettings.language)
                    .Append(DEL)
                    .Append(FileSettings.gender)
                    .Append(DEL)
                    .Append(FileSettings.country)
                    .Append(DEL)
                    .Append(FileSettings.versusCountry)
                    .Append(DEL)
                    .Append(FileSettings.countryIndex)
                    .Append(DEL)
                    .Append(FileSettings.versusCountryIndex);
            File.WriteAllText(SETTINGS_PATH, stringBuilder.ToString());
        }

        //lodanje podataka iz file u fileSettings klasu
        public static List<string> LoadSettings()
        {
            string[] lines = File.ReadAllLines(SETTINGS_PATH);
            List<string> myList = new List<string>();
            foreach (string item in lines)
            {
                string[] data = item.Split(DEL);
                myList.Add(data[0]);
                myList.Add(data[1]);
                myList.Add(data[2]);
                myList.Add(data[3]);
                myList.Add(data[4]);
                myList.Add(data[5]);

                FileSettings.language = data[0];
                FileSettings.gender = Convert.ToBoolean(data[1]);
                FileSettings.country = data[2];
                FileSettings.versusCountry = data[3];
                FileSettings.countryIndex = int.Parse(data[4]);
                FileSettings.versusCountryIndex = int.Parse(data[5]);
            }
            return myList;
        }

        //Spremanje favorita u file 
        public static void SaveFavourites(HashSet<string> favourites)
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in favourites)
            {
                stringBuilder.AppendLine(item);
            }
            File.WriteAllText(FAVOURITES_PATH, stringBuilder.ToString());
        }

        //lodanje favorita u file settigns klasu
        public static HashSet<string> LoadFavourites()
        {
            string[] lines = File.ReadAllLines(FAVOURITES_PATH);
            HashSet<string> myList = new HashSet<string>();
            foreach (string item in lines)
            {
                myList.Add(item);
            }
            FileSettings.favourites = myList;
            return myList;
        }

        //postavljanje kulture(jezika)
        public static void SetCulture(string language)
        {
            var culture = new CultureInfo(language);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
        public static void LoadLanguage()
        {
            if (FileSettings.language == "Croatian")
            {
                SetCulture(EN);
            }
            else
            {
                SetCulture(HR);
            }
        }

        //Lodanje drzava
        public static Task<HashSet<Teams>> LoadJsonTeams()
        {
            if (File.Exists(ConstantsApi.FemaleDetailedMatchesWebLocation) && File.Exists(ConstantsApi.MaleTeamsLocation))
            {
                //Lodanje iz file
                if (FileSettings.gender)
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ConstantsApi.FemaleTeamsLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Teams>>(json);
                        }
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ConstantsApi.MaleTeamsLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Teams>>(json);
                        }
                    });
                }
            }
            else
            {
                //Lodanje s weba
                if (FileSettings.gender)
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ConstantsApi.FemaleTeamsWebLocation);
                        var response = apiClient.Execute<HashSet<Teams>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Teams>>(response.Content);
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ConstantsApi.MaleTeamsWebLocation);
                        var response = apiClient.Execute<HashSet<Teams>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Teams>>(response.Content);
                    });
                }
            }
        }

        //Lodanje igraca
        public static Task<HashSet<Games>> LoadJsonMatches()
        {
            if (File.Exists(ConstantsApi.FemaleMatchesLocation) || File.Exists(ConstantsApi.MaleMatchesLocation))
            {
                //Lodanje iz file
                if (FileSettings.gender)
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ConstantsApi.FemaleMatchesLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Games>>(json);
                        }
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ConstantsApi.MaleMatchesLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Games>>(json);
                        }
                    });
                }
            }
            else
            {
                //Lodanje s weba
                if (FileSettings.gender)
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ConstantsApi.FemaleDetailedMatchesWebLocation);
                        var response = apiClient.Execute<HashSet<Games>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Games>>(response.Content);
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ConstantsApi.MaleDetailedMatchesWebLocation);
                        var response = apiClient.Execute<HashSet<Games>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Games>>(response.Content);
                    });
                }
            }
        }

        //Lodanje detalja drzava
        public static Task<HashSet<Results>> LoadJsonResults()
        {
            if (File.Exists(ConstantsApi.FemaleTeamsLocation) && File.Exists(ConstantsApi.MaleResultsLocation))
            {
                //Lodanje iz file
                if (FileSettings.gender)
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ConstantsApi.FemaleResultsLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Results>>(json);
                        }
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        using (StreamReader reader = new StreamReader(ConstantsApi.MaleResultsLocation))
                        {
                            string json = reader.ReadToEnd();
                            return JsonConvert.DeserializeObject<HashSet<Results>>(json);
                        }
                    });
                }
            }
            else
            {
                //Lodanje s weba
                if (FileSettings.gender)
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ConstantsApi.FemaleTeamsWebLocation);
                        var response = apiClient.Execute<HashSet<Results>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Results>>(response.Content);
                    });
                }
                else
                {
                    return Task.Run(() =>
                    {
                        var apiClient = new RestClient(ConstantsApi.MaleTeamsWebLocation);
                        var response = apiClient.Execute<HashSet<Results>>(new RestRequest());
                        return JsonConvert.DeserializeObject<HashSet<Results>>(response.Content);
                    });
                }
            }
        }
        public static Image GetPicture()
        {
            return Resources.defaultUser;
        }
    }
}
