using System.Diagnostics;
using VideoStoreDomain;
using FluentAssertions;
using Xunit;

namespace VideoStoreDomainTests
{
    public class VideoStoreTest
    {
        [Fact]
        public void ShouldInstantiate()
        {
            var sut = new Customer("Fred");
            sut.Should().NotBeNull();
        }

        [Fact]
        public void testSingleNewReleaseStatement()
        {
            var customer = new Customer("Fred");
            customer.addRental(new Rental(new Movie("The Cell", Movie.NEW_RELEASE), 3));
            Assert.Equal("Rental Record for Fred\n\tThe Cell\t9.0\nYou owed 9.0\nYou earned 2 frequent renter points\n", customer.statement());
        }

        [Fact]
        public void testDualNewReleaseStatement()
        {
            var customer = new Customer("Fred");
            customer.addRental(new Rental(new Movie("The Cell", Movie.NEW_RELEASE), 3));
            customer.addRental(new Rental(new Movie("The Tigger Movie", Movie.NEW_RELEASE), 3));
            Assert.Equal("Rental Record for Fred\n\tThe Cell\t9.0\n\tThe Tigger Movie\t9.0\nYou owed 18.0\nYou earned 4 frequent renter points\n", customer.statement());
        }

        [Fact]
        public void testSingleChildrensStatement()
        {
            var customer = new Customer("Fred");
            customer.addRental(new Rental(new Movie("The Tigger Movie", Movie.CHILDRENS), 3));
            Assert.Equal("Rental Record for Fred\n\tThe Tigger Movie\t1.5\nYou owed 1.5\nYou earned 1 frequent renter points\n", customer.statement());
        }

        [Fact]
        public void testMultipleRegularStatement()
        {
            var customer = new Customer("Fred");
            customer.addRental(new Rental(new Movie("Plan 9 from Outer Space", Movie.REGULAR), 1));
            customer.addRental(new Rental(new Movie("8 1/2", Movie.REGULAR), 2));
            customer.addRental(new Rental(new Movie("Eraserhead", Movie.REGULAR), 3));

            Assert.Equal("Rental Record for Fred\n\tPlan 9 from Outer Space\t2.0\n\t8 1/2\t2.0\n\tEraserhead\t3.5\nYou owed 7.5\nYou earned 3 frequent renter points\n", customer.statement());
        }

    }
}