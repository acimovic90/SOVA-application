using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPortfolio2.Controllers
{
    public class BaseController : Controller //
    {
        protected bool IsLastPage(int page, int pageSize, int total)
        {
            if (total - (page * pageSize + pageSize) > 0)
            {
                return false;
            }
            return true;
        }

        protected static bool IsFirstPage(int page)
        {
            return page == 0;
        }

        protected string GetNextUrl(IUrlHelper url, string route, int page, int pageSize, int total)
        {
            if (IsLastPage(page, pageSize, total)) return null;
            return url.Link(route, new { page = page + 1, pageSize });
        }
        protected string GetPrevUrl(IUrlHelper url, string route, int page, int pageSize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(route, new { page = page - 1, pageSize });
        }
    }
}
