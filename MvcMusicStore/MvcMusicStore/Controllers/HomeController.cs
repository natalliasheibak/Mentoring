using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using MvcMusicStore.Models;
using System.Diagnostics;
using MvcMusicStore.PerformanceCounters;
using log4net;
using System.Reflection;

namespace MvcMusicStore.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly MusicStoreEntities _storeContext = new MusicStoreEntities();

        // GET: /Home/
        public async Task<ActionResult> Index()
        {
            log.Error("The Home page was opened.");
            return View(await _storeContext.Albums
                .OrderByDescending(a => a.OrderDetails.Count())
                .Take(6)
                .ToListAsync());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _storeContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}