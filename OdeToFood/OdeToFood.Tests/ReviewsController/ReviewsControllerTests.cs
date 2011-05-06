using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using OdeToFood.Controllers;
using OdeToFood.Tests.Doubles;
using OdeToFood.Models;
using System.Web.Mvc;

namespace OdeToFood.Tests
{
    [TestFixture]
    public class ReviewsControllerTests
    {
        FakeDbContext _db;

        [SetUp]
        public void Setup()
        {
            _db = new FakeDbContext();
            _db.Reviews = new[] { 
                    new Review(), 
                    new Review(), 
                    new Review(), 
                    new Review()
            }.AsQueryable();
        }

        [Test]
        public void Index_Action_Model_Is_Three_Reviews()
        {                        
            var controller = new ReviewsController(_db);
            var result = controller.Index() as ViewResult;
            var model = result.Model as IEnumerable<Review>;
            
            Assert.AreEqual(3, model.Count());
        }

        [Test]
        public void Edit_Action_Saves_Updated_Review()
        {
            var editedReview = new Review();
            var controller = new ReviewsController(_db);
            controller.Edit(editedReview);

            Assert.IsTrue(_db.Reviews.Contains(editedReview));
        }

        [Test]
        public void Edit_Action_Saves_Changes()
        {
            var editedReview = new Review();
            var controller = new ReviewsController(_db);
            controller.Edit(editedReview);

            Assert.IsTrue(_db.ChangesSaved);
        }
    }
}
