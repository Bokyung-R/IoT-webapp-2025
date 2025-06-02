using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyPortfolioWebApp.Models;

namespace MyPortfolioWebApp.Controllers
{
    public class NewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: News . http://locahost:5234/News/Index 요청했음
        public async Task<IActionResult> Index(int page = 1)
        {
            // 뷰쪽에 보내고 싶은 데이터
            //ViewData["Key"] //ViewBag.Title //TempData["Key"]
            ViewData["Title"] = "서버에서 변경가능!!";
            // _context News
            // SELECT * FROM News.
            //return View(await _context.News
            //                       .OrderByDescending(o => o.PostDate)
            //                       .ToListAsync()); // 뷰화면에 데이터를 가지고감
            // 쿼리로 처리 방식. DB 저장프로시저로도 처리가능
            //var news = await _context.News.FromSql($@"SELECT Id, Writer, Title, Description, PostDate, ReadCount
            //                                          FROM News")
            //                        .OrderByDescending(o => o.PostDate)
            //                        .ToListAsync();

            //return View(news);

            // 최종 단계
            var totalCount = _context.News.Count();

            var countList = 10; // 한 페이지에 보여줄 뉴스 수
            var totalPage = totalCount / countList;
            if (totalCount % countList > 0) totalPage++; // 나머지가 있으면 페이지 하나 추가

            if (totalPage < page) page = totalPage;

            var countPage = 10; // 페이지 네비게이션에서 보여줄 최대 페이지 수
            var startPage = ((page - 1) / countPage) * countPage + 1;
            var endPage = startPage + countPage - 1;
            if (totalPage < endPage) endPage = totalPage;

            var startCount = ((page - 1) * countList) + 1;
            var endCount = startCount + countList - 1;

            // View로 넘기는 데이터 (페이징 숫자 컨트롤용)
            ViewBag.StartPage = startPage;
            ViewBag.EndPage = endPage;
            ViewBag.Page = page;
            ViewBag.TotalPage = totalPage;

            // 저장 프로시저 호출로 페이징된 데이터 가져오기
            var news = await _context.News
                .FromSqlInterpolated($"CALL New_PagingBoard({startCount}, {endCount})")
                .ToListAsync();

            return View(news);


        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // SELECT * FROM News WHERE id = @id
            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            // 조회수 증가 로직
            news.ReadCount++;
            _context.News.Update(news);
            await _context.SaveChangesAsync();

            return View(news);
        }

        // GET: http://localhost:5234/News/Create GET method로 호출!!
        public IActionResult Create()
        {
            var news = new News
            {
                Writer = "관리자",
                PostDate = DateTime.Now,
                ReadCount = 0,
            };
            return View(news);  // View로 데이터를 가져갈게 아무것도 없음
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // <form asp-controller="News" asp-action="Create"> 이 http://localhost:5234/News/Create 포스트메서드 호출
        public async Task<IActionResult> Create([Bind("Id,Title,Description")] News news)
        {
            if (ModelState.IsValid)
            {
                news.Writer = "관리자"; // 작성자는 자동으로 관리자
                news.PostDate = DateTime.Now; // 게시일자는 현재
                news.ReadCount = 0;

                // INSERT INTO...
                _context.Add(news);
                // COMMIT
                await _context.SaveChangesAsync();

                TempData["success"] = "뉴스 저장 성공!";
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // SELECT * FROM News WHERE id = @id
            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description")] News news)
        {
            if (id != news.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // 방식2 원본을 찾아서 수정해주는 방식
                    var existingNews = await _context.News.FindAsync(id);
                    if (existingNews == null)
                    {
                        return NotFound();
                    }

                    existingNews.Title = news.Title;
                    existingNews.Description = news.Description;

                    // UPDATE News SET ...
                    //_context.Update(news); // 방식1 ID가 같은 새글을 UPDATE하면 수정                    
                    // COMMIT
                    await _context.SaveChangesAsync();
                    TempData["success"] = "뉴스 수정 성공!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            if (news != null)
            {
                // DELETE FROM News WHERE id = @id
                _context.News.Remove(news);
            }
            // COMMIT
            await _context.SaveChangesAsync();

            TempData["success"] = "뉴스 삭제 성공!";
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.Id == id);
        }
    }
}