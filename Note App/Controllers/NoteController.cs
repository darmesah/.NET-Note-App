using Microsoft.AspNetCore.Mvc;
using Note_App.Data;
using Note_App.Models;

namespace Note_App.Controllers
{
	public class NoteController : Controller
	{
		private readonly ApplicationDbContext _db;
		public NoteController(ApplicationDbContext db)
		{
			_db = db;
		}

		public IActionResult Index()
		{
			List<Note> objNoteList = _db.Notes.ToList();
			return View(objNoteList);
		}

		public IActionResult Details(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}

			Note? singleNote = _db.Notes.Find(id);

			if (singleNote == null)
			{
				return NotFound();
			}

			return View(singleNote);
		}

		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Note obj)
		{
			if (ModelState.IsValid)
			{
				_db.Notes.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View();
		}

		public IActionResult Edit(int? id)
		{
			Note? singleNote = _db.Notes.Find(id);

			if (singleNote == null)
			{
				return NotFound();
			}

			return View(singleNote);
		}

		[HttpPost]
		public IActionResult Edit(Note obj)
		{
			if (ModelState.IsValid)
			{
				_db.Notes.Update(obj);
				_db.SaveChanges();
				return RedirectToAction($"{obj.Id}");
			}
			return View();
		}

	}
}
