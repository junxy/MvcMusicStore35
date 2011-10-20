using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.Data;
using MvcMusicStore.Models;
using System.Data;

namespace MvcMusicStore.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            // Get most popular albums
            var albums = GetTopSellingAlbums(5);

            return View(albums);
        }

        private List<Album> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count

            var db = Database.Open("MvcMusicStore");

            var dt = db.Query("SELECT top (" + count + ") [AlbumId],[GenreId],[ArtistId],[Title],[Price],[AlbumArtUrl] FROM [Albums]");

            var list = new List<Album>(dt.Rows.Count);

            foreach (DataRow dr in dt.Rows)
            {
                var d = new Album()
                {
                    AlbumId = Convert.ToInt32(dr["AlbumId"]),
                    GenreId = Convert.ToInt32(dr["GenreId"]),
                    ArtistId = Convert.ToInt32(dr["ArtistId"]),
                    Title = dr["Title"].ToString(),
                    Price = Convert.ToDecimal(dr["Price"]),
                    AlbumArtUrl = dr["AlbumArtUrl"].ToString(),
                };
                list.Add(d);
            }
            return list;
        }
    }
}
