using PagedList;
using System;
using System.Linq;
using System.Web.Mvc;
using Top2000.ViewModels;

namespace Top2000.Controllers
{
    public class SongsController : Controller
    {
        public static readonly int PAGE_SIZE = 10;

        public ActionResult All(int? page)
        {
            Func<int, string> PageUrlGenerator = (newPage) => Url.Action("All", new
            {
                page = newPage,
            });

            ViewBag.PageUrlGenerator = PageUrlGenerator;
            ViewBag.UseIndex = false;

            using (var db = new Entities())
            {
                var result = db.Songs
                    .Select((model) => new SongViewModel
                    {
                        Rank = model.SongID,
                        Title = model.SongTitle,
                        Artists = model.Artists
                            .Select((artist) => artist.ArtistName)
                            .ToList(),
                        Year = model.ReleaseDate.Year
                    })
                    .ToList()
                    .ToPagedList(page ?? 1, PAGE_SIZE);

                return View(result);
            }
        }

        [Route("Songs/Popular")]
        public ActionResult PopularByYear(int? year, int? page)
        {
            year = year ?? DateTime.Now.Year - 1;

            Func<int, string> PageUrlGenerator = (newPage) => Url.Action($"Popular", new
            {
                year,
                page = newPage,
            });

            ViewBag.PageUrlGenerator = PageUrlGenerator;
            ViewBag.Year = year;
            ViewBag.UseIndex = false;

            using (var db = new Entities())
            {
                var result = db.SongRanks
                    .Where(rank => rank.Year == year)
                    .OrderBy(rank => rank.Rank)
                    .Select(rank => new SongViewModel
                    {
                        Rank = rank.Rank,
                        Title = rank.Song.SongTitle,
                        Artists = rank.Song.Artists
                            .Select(artist => artist.ArtistName)
                            .ToList(),
                        Year = rank.Song.ReleaseDate.Year
                    })
                    .ToList()
                    .ToPagedList(page ?? 1, PAGE_SIZE);

                return View(result);
            }
        }

        [Route("Songs/Top10")]
        public ActionResult Top10ByYear(int? year)
        {
            year = year ?? DateTime.Now.Year - 1;

            ViewBag.Year = year;
            ViewBag.UseIndex = true;

            using (var db = new Entities())
            {
                var result = db.SongRanks
                    .Where(rank => rank.Year == year && rank.Song.ReleaseDate.Year == year)
                    .OrderBy(rank => rank.Rank)
                    .Take(10)
                    .Select((rank) => new SongViewModel
                    {
                        Rank = rank.Rank,
                        Title = rank.Song.SongTitle,
                        Artists = rank.Song.Artists
                            .Select((artist) => artist.ArtistName)
                            .ToList(),
                        Year = rank.Song.ReleaseDate.Year
                    })
                    .ToList();

                return View(result);
            }
        }
    }
}