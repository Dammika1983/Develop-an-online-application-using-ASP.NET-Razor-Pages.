using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMusic.Data;
using RazorPagesMusic.Models;

namespace RazorPagesMusic.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMusic.Data.RazorPagesMusicContext _context;

        public IndexModel(RazorPagesMusic.Data.RazorPagesMusicContext context)
        {
            _context = context;
        }

        public IList<Music> Song { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Artist { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SongArtist { get; set; }

        public async Task OnGetAsync()
        {
            var songs = from m in _context.Song
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                songs = songs.Where(s => s.Artist.Contains(SearchString));
            }

            Song = await songs.ToListAsync();
        }
    }


}
