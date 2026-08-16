using Banking.Domain.Common;
using Banking.Domain.Customers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Banking.UnitTest;

[TestClass]
public class CustomerTests
{
    [TestMethod]
    public void Customer_WithValidData_ShouldBeCreated()
    {
        var customer = new Customer("10000000", "Test", "Test", "Test", "Test");

        Assert.IsNotNull(customer);
    }

    [TestMethod]
    public void Customer_WhenCreated_ShouldBeActive()
    {
        var customer = new Customer("10000000", "Test", "Test", "Test", "Test");

        Assert.AreEqual(CustomerStatus.Active, customer.Status);
    }


    [TestMethod]
    public void Customer_WhenCreated_ShouldHaveId()
    {
        var customer = new Customer("10000000", "Test", "Test", "Test", "Test");

        Assert.IsNotNull(customer.Id);
    }


    [TestMethod]
    public void Customer_WhenCreated_ShouldHaveCreatedAt()
    {
        var customer = new Customer("10000000", "Test", "Test", "Test", "Test");

        Assert.IsNotNull(customer.CreatedAt);
        Assert.IsTrue(customer.CreatedAt <= DateTimeOffset.UtcNow);
    }

    [TestMethod]
    public void Customer_WithEmptyFirstName_ShouldFail()
    {
        Assert.ThrowsException<DomainException>(()=>
        {
            var customer = new Customer("10000000", "", "Test", "Test", "Test");
        });
    }


    [TestMethod]
    public void Customer_WithEmptyLastName_ShouldFail()
    {
        Assert.ThrowsException<DomainException>(() =>
        {
            var customer = new Customer("10000000", "Test", "", "Test", "Test");
        });
    }

    [TestMethod]
    public void Customer_WithEmptyNationalCode_ShouldFail()
    {
        Assert.ThrowsException<DomainException>(() =>
        {
            var customer = new Customer("10000000", "Test", "Test", "", "Test");
        });
    }

    [TestMethod]
    public void Customer_WithEmptyMobile_ShouldFail()
    {
        Assert.ThrowsException<DomainException>(() =>
        {
            var customer = new Customer("10000000", "Test", "Test", "Test", "");
        });
    }

    [TestMethod]
    public void Block_ShouldChangeStatusToBlocked()
    {
        var customer = new Customer("10000000", "Test", "Test", "Test", "Test");

        customer.Block();

        Assert.AreEqual(CustomerStatus.Blocked, customer.Status);
    }

    [TestMethod]
    public void Activate_ShouldChangeStatusToActive()
    {
        var customer = new Customer("10000000", "Test", "Test", "Test", "Test");

        customer.Activate();

        Assert.AreEqual(CustomerStatus.Active, customer.Status);
    }

}
