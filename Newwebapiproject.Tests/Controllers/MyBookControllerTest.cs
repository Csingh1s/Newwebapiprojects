using Microsoft.AspNetCore.Mvc;
using Moq;
using Newwebapiproject.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Newwebapiproject.Tests.Controllers
{
    public  class MyBookControllerTest
    {
        [Fact]
        public void Get_Returns_ALL_Books()
        {
            //Follow AAA
            //Arrange ( declaring variables, instantiating mocks)
            var count = 3;
            var controller = new MyBookController();

            //ACT ( call method which i really want to test)
            var getresult = (ActionResult<IEnumerable<MyBook>>)controller.Get();
            var books = getresult.Value;

            //TestCase 1. Check if getresult is not null.
            //TestCase 2. Check if  Mybooks is not null.
            //TestCase 3. Count any number of books presented in Mybook.

            //Assert ( Test each statements mentioned above)
            Assert.True(books.Any());
            Assert.NotNull(getresult);
            Assert.NotNull(books);
            Assert.Equal(6, books.Count());
            Assert.NotEqual(2, books.Count());
        }

        [Fact]
        public void GetById_Return_Existing_Book() 
        { 
            //Arrange
             var controller = new MyBookController();
            //Act

            var getresult = controller.GetById(1) as ActionResult<MyBook>;
            var book = getresult.Value;
            
            //Assert

            //Test Case 1. Check if getresult is not null.
            //Test Case 2. Check if  Mybooks is not null.
            //Test Case 3. Count no. 1 book  as we have enter 1 in GetById.
            //Test Case 4.  Id shoule not be equal to current book Id.
            //Test Case12121

            Assert.NotNull(getresult);
            Assert.NotNull(book);
            Assert.Equal(1, book.Id);
            Assert.NotEqual(2,book.Id);

        }
        [Fact]
        public void GetById_NonExsiting_ReturnNotFound()
        {
            //Arrange
            var controller = new MyBookController();

            //Act
            var getresult = controller.GetById(99);
            
            var objectresult = getresult.Result as NotFoundResult;
            
            //Test Case 1. Check if id with 99 should return NotFound.
            //Test Case 2. Verify Not Found Status Code.

            // Assert
            Assert.NotNull(getresult);
            Assert.Equal((int)HttpStatusCode.NotFound, objectresult.StatusCode);
        }
        [Fact]
        public void Create_NewMyBook_ReturnNewMyBook()
        {
            //Arrange
            var myBook = new MyBook();
            var conroller = new MyBookController();
            var newMyBook = new MyBook { Id = 5 , Title = "MyNewAuthor", Author = "MyNewAuthor", Publishyear = 2008};
         

            //Act
            var getresult = conroller.Create(newMyBook);
            var objectresult = getresult.Result as CreatedAtActionResult;
            var mybookprop = objectresult.Value as MyBook;
            

            // Test Case 1. Verify Success Status Code 201.
            // Test Case 2. Verify Object is created. 
            // Test case 3. Verify if title matches with expected title.

            
            //Assert
            Assert.NotNull(getresult);
            Assert.NotNull(objectresult);
            Assert.Equal(201, objectresult.StatusCode);
            Assert.IsType<Newwebapiproject.MyBook>(objectresult.Value);
            //Assert.Equal("MyNewAuthor", mybookprop.Title);

        }
        [Fact]
        public void Update_Mybook_ReturnUpdatedMyBook()
        {
            //Arrange

            var controller = new MyBookController();
            var newUpdatedbook = new MyBook {Title = "HarryPorter-2", Author = "Chandra Singh"};

            //Act

            var getresult = controller.Update(1, newUpdatedbook); // updating  Id = 1. 
            var objectresult = getresult as OkObjectResult;
            var mybookprop = objectresult.Value as MyBook;
           

            // Test Case 1. Verify  return is not Null.
            // Test Case 2. Verify success Status// 200.
            // Test Case 3. Verify if Title and Author are updated.
            // Hello World-347895
            //Assert
            Assert.NotNull(getresult);
            Assert.NotNull(objectresult);
           // Assert.NotNull(mybookprop);
            Assert.Equal(newUpdatedbook.Title, mybookprop.Title);
            Assert.Equal(newUpdatedbook.Author, mybookprop.Author);
        }


        [Fact]
        public void  Delete_Mybook_ReturnOk()
        {
            //Assert

            var controller = new MyBookController();
            var myreamingbook = new MyBook();

            //Act

            var getresult = controller.DeleteById(1); // Delete ID 1
            var objectresult = getresult as OkObjectResult;
           
           
            // Test Case 1. Verify getresult is not null.
            // Test Case 2. Verify if objectresult is not null.
            // Test Case 3. Verify if status code is okay which is 200. 
            //Arrange

            Assert.NotNull(getresult);
            Assert.NotNull(objectresult);
            Assert.Equal((int)HttpStatusCode.OK, objectresult.StatusCode);

        }

    }
}
