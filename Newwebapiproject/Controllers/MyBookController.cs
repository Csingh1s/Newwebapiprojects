using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Newwebapiproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyBookController : ControllerBase
    {
        private readonly List<MyBook> _mybooks = new List<MyBook>()
        {
           new MyBook {Id =1, Title = "HarryPorter-1", Author ="Shekhar Singh", Publishyear = 1984},
           new MyBook {Id =2, Title = "HarryPorter-2", Author ="Milka Singh", Publishyear = 1985},
           new MyBook {Id =3, Title = "HarryPorter-3", Author ="Rama Singh", Publishyear = 1986}
        };

        //CRUD Operations

        //Get method to get all books 
        [HttpGet]
        public ActionResult<IEnumerable<MyBook>> Get() { return _mybooks; }


        // Get MyBook by ID
        [HttpGet("id")]
        public ActionResult<MyBook> GetById(int id)
        {
            var mybook = _mybooks.FirstOrDefault(x => x.Id == id);
            if (mybook == null)
            {
                return NotFound(); // return 404 status Not found Status
            }
  
           return mybook;

        }

        // Create new MyBook, 
        [HttpPost]

        public ActionResult<MyBook> Create(MyBook book)
        {
            book.Id =_mybooks.Max(x => x.Id)+1;
      
            _mybooks.Add(book);
            
            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book); // return HTTP201 
            //return Ok(_mybooks);
        }

        // update
        [HttpPut("{id}")]
        public IActionResult Update (int id , MyBook book)
        {
            var exist_mybook = _mybooks.FirstOrDefault(b => b.Id == id);
            if(exist_mybook == null)
            {
                return NotFound();
            }
            exist_mybook.Title = book.Title;
            exist_mybook.Author = book.Author;
            exist_mybook.Publishyear = book.Publishyear;
            return Ok(exist_mybook);

        }

        [HttpDelete("id")]
        public IActionResult DeleteById(int id)
        {
            var exist_mybook = _mybooks.Find(x => x.Id == id);
            if(exist_mybook == null)
            {
                return NotFound();
            }
            _mybooks.Remove(exist_mybook);
            return Ok(_mybooks);
        }
    }
}
