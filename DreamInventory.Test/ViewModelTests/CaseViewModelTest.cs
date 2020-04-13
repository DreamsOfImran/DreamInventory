using System;
using System.Collections.Generic;
using DreamInventory.Services;
using DreamInventory.ViewModels;
using Moq;
using NSubstitute;
using Xunit;

namespace DreamInventory.Test
{
    public class CaseViewModelTest
    {
        private readonly CaseApiServices caseApiService = Substitute.For<CaseApiServices>();
        //private readonly Mock<caseApiService> caseApiServiceMock = new Mock<CaseApiServices>();


        [Fact]
        public void GetCaseList_test()
        {
            var CaseList = new List<Cases>
            {
                new Cases
                {
                    Id = 1,
                    CaseNo = "Ar-202"
                },
                new Cases
                {
                    Id = 2,
                    CaseNo = "Ar-203"
                }
            };
            var mockData = new CaseData
            {
                TotalCount = 2,
                cases = CaseList
            };

            caseApiService.GetCases(1, "", "").Returns(mockData);
            var newCaseViewModel = new CaseViewModel();
            var result = newCaseViewModel.GetCaseList(1);

            Assert.Equal(2, result.TotalCount);
            Assert.Equal("Ar-203", result.cases.Find(x => x.Id == 2).CaseNo);
        }

        [Fact]
        public void SelectedCase_test()
        {
            var sampleCase = new Cases
            {
                Id = 1,
                CaseNo = "Br-202"
            };
            caseApiService.GetSelectedCase(sampleCase).Returns(sampleCase);
            var newCaseViewModel = new CaseViewModel();

            var result = newCaseViewModel.SelectedCase(1);

            Assert.Equal("Br-202", result.CaseNo);
        }
    }
}
