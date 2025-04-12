using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PlayNext;

class Program
{
    static void Main(string[] args)
    {
        // Get the files with greatest count
        var files = Directory.GetFiles(".");
        var extensions = files
            .Select(f => f.Split('.').Last())
            .GroupBy(e => e)
            .Select(x => new { Extension = x.Key, Count = x.Count()});
        var vidExtension = extensions.OrderByDescending(a => a.Count).First().Extension;
        var movies = files.Where(f => f.Contains(vidExtension));

        // Get next episode from save file
        var saveFile = files.FirstOrDefault(f => f.EndsWith(".SAVE"));
        var nextEpisode = saveFile == null ? 0 : int.Parse( Regex.Replace(saveFile, @"\D", "") );
        nextEpisode = nextEpisode < movies.Count() ? nextEpisode : 0;

        // Start the video with default program
        Process.Start(new ProcessStartInfo { 
            FileName = movies.ElementAt(nextEpisode), 
            UseShellExecute = true 
        });     

        // Update Save File
        if(saveFile != null) {
            File.Delete(saveFile);
        }
        File.Create($"{nextEpisode+1}.SAVE"); 
    }
}
