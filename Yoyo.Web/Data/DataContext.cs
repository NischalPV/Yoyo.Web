using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Pluralization;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Yoyo.Web.Models;

namespace Yoyo.Web.Data
{
    public class DataContext : IDataContext
    {

        // Set deafule data path to "Data" Directory in the project 
        private string dataPath = $"{Directory.GetCurrentDirectory()}/Data";

        /// <summary>
        /// Pluralize given word
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Pluralized word</returns>
        private string Pluralize(string word)
        {
            var pluraizationService = new EnglishPluralizationService();
            return pluraizationService.Pluralize(word);
        }

        /// <summary>
        /// Reads Atheletes.json file, deserializes json to List of Athelete model
        /// </summary>
        /// <returns>List<Athelete></returns>
        public async Task<List<Athelete>> Atheletes()
        {
            string jsonFile = Pluralize(nameof(Athelete)); // Necessary to automate the reading of Atheletes.json file
            using (FileStream fs = File.OpenRead($"{dataPath}/{jsonFile}.json"))
            {
                try
                {
                    return await JsonSerializer.DeserializeAsync<List<Athelete>>(fs);
                }
                catch (Exception ex) { return default; }
            }
        }

        /// <summary>
        /// Reads FitnessRatings.json file, deserializes json to List of FitnessRating model
        /// </summary>
        /// <returns></returns>
        public async Task<List<FitnessRating>> FitnessRatings()
        {
            string jsonFile = Pluralize(nameof(FitnessRating)); // Necessary to automate the reading of FitnessRatings.json file
            using (FileStream fs = File.OpenRead($"{dataPath}/{jsonFile}.json"))
            {
                try
                {
                    return await JsonSerializer.DeserializeAsync<List<FitnessRating>>(fs);
                }
                catch (Exception ex) { return default; }
            }
        }
    }
}
