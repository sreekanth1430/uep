using Casestudy11.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
using Casestudy11.Controllers;
using Casestudy11.Data;
using Casestudy11.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Casestudy11uep.Controllers;

namespace Unit_SkillMgnt
{
    [TestClass]
    public class UnitTest1
    {

        public void prepareTestDb(in TestSkillMgntContext context)
        {
            context.SkillMaster.Add(new SkillMaster { skillId = 1001, name = "c#", skillCatName = "MS" });
            context.SkillMaster.Add(new SkillMaster { skillId = 1002, name = "ASP.NET", skillCatName = "UEP" });
            context.SkillMaster.Add(new SkillMaster { skillId = 1003, name = "Angular", skillCatName = "Project" });

            context.EmployeeInfo.Add(new EmployeeInfo { empId = 2001, empName = "Mary", empEmailId = "mary.s@sonata-software.com", project = "", pmId = null, pmEmailId = "", role = "Manager", grade = "", hccOrganization = "" });
            context.EmployeeInfo.Add(new EmployeeInfo { empId = 2002, empName = "sheela", empEmailId = "sheela.e.n@sonata-software.com", project = "", pmId = null, pmEmailId = "", role = "Manager", grade = "", hccOrganization = "" });
            context.EmployeeInfo.Add(new EmployeeInfo { empId = 2003, empName = "shamanth", empEmailId = "shamanth.n@sonata-software.com", project = "UEP", pmId = context.EmployeeInfo.Find(2001), pmEmailId = "mary.s@sonata-software.com", role = "developer", grade = "", hccOrganization = "" });
            context.EmployeeInfo.Add(new EmployeeInfo { empId = 2004, empName = "akshit", empEmailId = "akshit.k@sonata-software.com", project = "UEP", pmId = context.EmployeeInfo.Find(2002), pmEmailId = "sheela.e.n@sonata-software.com", role = "developer", grade = "", hccOrganization = "" });
            context.EmployeeInfo.Add(new EmployeeInfo { empId = 2005, empName = "sreekanth", empEmailId = "sreekanth.g@sonata-software.com", project = "UEP", pmId = context.EmployeeInfo.Find(2001), pmEmailId = "mary.s@sonata-software.com", role = "developer", grade = "", hccOrganization = "" });

            context.EmployeeSkill.Add(new EmployeeSkill { pkAuto = 1, primary = 1, empId = context.EmployeeInfo.Find(2003), empName = "shamanth", rating = 5, hccOrganization = "", grade = "ETG", lastUpdatedDate = DateTime.Now, skillStartDate = DateTime.Now, skillEndDate = DateTime.Now, group = "", skillType = "project", approvedBy = "", approvedDate = null, SkillId = context.SkillMaster.Find(1001), approvalStatus = 0 });
            context.EmployeeSkill.Add(new EmployeeSkill { pkAuto = 2, primary = 0, empId = context.EmployeeInfo.Find(2003), empName = "shamanth", rating = 4, hccOrganization = "", grade = "ETG", lastUpdatedDate = DateTime.Now, skillStartDate = DateTime.Now, skillEndDate = DateTime.Now, group = "", skillType = "project", approvedBy = "", approvedDate = null, SkillId = context.SkillMaster.Find(1002), approvalStatus = 0 });
            context.EmployeeSkill.Add(new EmployeeSkill { pkAuto = 3, primary = 1, empId = context.EmployeeInfo.Find(2004), empName = "akshit", rating = 5, hccOrganization = "", grade = "ETG", lastUpdatedDate = DateTime.Now, skillStartDate = DateTime.Now, skillEndDate = DateTime.Now, group = "", skillType = "project", approvedBy = "", approvedDate = null, SkillId = context.SkillMaster.Find(1001), approvalStatus = 0 });
            context.EmployeeSkill.Add(new EmployeeSkill { pkAuto = 4, primary = 0, empId = context.EmployeeInfo.Find(2005), empName = "sreekanth", rating = 5, hccOrganization = "", grade = "ETG", lastUpdatedDate = DateTime.Now, skillStartDate = DateTime.Now, skillEndDate = DateTime.Now, group = "", skillType = "project", approvedBy = "", approvedDate = null, SkillId = context.SkillMaster.Find(1001), approvalStatus = 0 });
            context.EmployeeSkill.Add(new EmployeeSkill { pkAuto = 5, primary = 1, empId = context.EmployeeInfo.Find(2005), empName = "sreekanth", rating = 5, hccOrganization = "", grade = "ETG", lastUpdatedDate = DateTime.Now, skillStartDate = DateTime.Now, skillEndDate = DateTime.Now, group = "", skillType = "project", approvedBy = "", approvedDate = null, SkillId = context.SkillMaster.Find(1002), approvalStatus = 0 });
        }
       
                [TestMethod]
                public void GetSkills()
                {
                    TestSkillMgntContext context = new TestSkillMgntContext();
                    prepareTestDb(in context);
                    var d = context.SkillMaster.Where(s => s.skillId == 3).FirstOrDefault();
                    //var x = context.SkillMaster.ToListAsync();

                    var controller = new SkillMastersController(context);
                    var res = controller.GetSkillMaster();

                    //var result = controller.GetProducts() as TestProductDbSet;

                    Assert.IsNotNull(1);
                    //Assert.AreEqual(3, result.Local.Count);
                }

              [TestMethod]
                public void TestGetLogin()
                {
                    TestSkillMgntContext context = new TestSkillMgntContext();

                    context.Login.Add(new Login { empid = "2001", pass = "2001" });
                    context.Login.Add(new Login { empid = "2002", pass = "2002" });
                    context.Login.Add(new Login { empid = "2003", pass = "2003" });
                    context.Login.Add(new Login { empid = "2004", pass = "2004" });
                    context.Login.Add(new Login { empid = "2005", pass = "2005" });
                    context.Login.Add(new Login { empid = "2006", pass = "2006" });

                    var controller = new LoginsController(context);
                    var res = controller.GetLogin("2001","2001");

                    Assert.IsNull(res.Exception);
                    Assert.AreEqual(res.Status.ToString(), "RanToCompletion");
                }
        
                        [TestMethod]
                        public void TestGetEmployeeSkill()
                        {
                            TestSkillMgntContext context = new TestSkillMgntContext();
                            prepareTestDb(in context);

                            var controller = new EmployeeSkillsController(context);
                            var res = controller.GetEmployeeSkill();

                            Assert.IsNotNull(res);
                        }

                        [TestMethod]
                        public void TestGetMgrEmployeeSkill()
                        {
                            TestSkillMgntContext context = new TestSkillMgntContext();
                            prepareTestDb(in context);

                            var controller = new EmployeeSkillsController(context);
                            var res = controller.GetMgrEmployeeSkill1("2001");

                            Assert.IsNull(res.Exception);
                            Assert.AreEqual(res.Status.ToString(), "RanToCompletion");
                        }
        /*     
                                    [TestMethod]
                                    public void DeleteEmployeeSkill()
                                    {
                                        TestSkillMgntContext context = new TestSkillMgntContext();
                                        prepareTestDb(in context);

                                        var controller = new EmployeeSkillsController(context);

                                        EmpIdSkillIdDto es = new EmpIdSkillIdDto { empId = "2003", skillId = "1002"};
                                        var res = controller.DeleteEmployeeSkill(es);
                                        int cnt = context.EmployeeSkill.ToList().Count;
                                        Assert.AreEqual(cnt, 4);
                                    }

                                          [TestMethod]
                                          public void TestPostEmployeeSkill()
                                          {
                                              TestSkillMgntContext context = new TestSkillMgntContext();
                                              prepareTestDb(in context);
                                              var controller = new EmployeeSkillsController(context);

                                              EmpSkillPostDTO empSkillPostDTO = new EmpSkillPostDTO { primary = "6", empId = "2004", rating = "4", skillStartDate = DateTime.Now, skillEndDate = DateTime.Now, group = "", skillType = "project", SkillId = "1002" };
                                              var res = controller.PostEmployeeSkill(empSkillPostDTO);

                                              int cnt = context.EmployeeSkill.ToList().Count;
                                              Assert.AreEqual(cnt, 6);
                                          }
        
                                  */
                                             [TestMethod]
                                          public void TestPutEmployeeSkill()
                                          {
                                              TestSkillMgntContext context = new TestSkillMgntContext();
                                              prepareTestDb(in context);
                                              var controller = new EmployeeSkillsController(context);

                                              EmpSkillPostDTO empSkillPostDTO = new EmpSkillPostDTO { primary = "0", empId = "2003", rating = "3", skillStartDate = DateTime.Now, skillEndDate = DateTime.Now, group = "", skillType = "project", SkillId = "1002" };
                                              var res = controller.PutEmployeeSkill(empSkillPostDTO);

                                              var check = context.EmployeeSkill.Find(2);

                                              Assert.AreEqual(check.primary, 0);
                                               // Assert.AreEqual(check.SkillId, 1002);
        }


    }
}
