using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TestHelper;
using Analyzer1;

namespace Analyzer1.Test
{
    [TestClass]
    public class UnitTest : CodeFixVerifier
    {
        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new Analyzer1CodeFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new Analyzer1Analyzer();
        }

        [TestMethod]
        public void NoRequiredProperty_Test()
        {
            var test = @"using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;

            namespace Analyzer1.Test.Entities
            {
                [DataContract]
                public class Class1
                {
                    public string ID {get;set;}
                }
            }
            ";

            var expected = new DiagnosticResult
            {
                Id = "Analyzer",
                Severity = DiagnosticSeverity.Warning,
                Message = String.Format("Entity should have the {0} property", "Name"),
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test0.cs", 9, 17)
                        }
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void NoAttribute_Test()
        {
            var test = @"using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;

            namespace Analyzer1.Test.Entities
            {
                public class Class1
                {
                    public string ID { get; set; }

                    public string Name { get; set; }
                }
            }
            ";
            var expected = new DiagnosticResult
            {
                Id = "Analyzer",
                Severity = DiagnosticSeverity.Warning,
                Message = String.Format("Type name '{0}' should have the 'DataContract' attribute", "Class1"),
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test0.cs", 9, 17)
                        }
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void NoPublicModificator_Test()
        {
            var test = @"using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;

            namespace Analyzer1.Test.Entities
            {
                [DataContract]
                class Class1
                {
                    public string ID { get; set; }

                    public string Name { get; set; }
                }
            }
            ";

            var expected = new DiagnosticResult
            {
                Id = "Analyzer",
                Severity = DiagnosticSeverity.Warning,
                Message = String.Format("Type name '{0}' should have the 'public' modificator", "Class1"),
                Locations =
                    new[] {
                                new DiagnosticResultLocation("Test0.cs", 9, 17)
                        }
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void NoPublicModificatorForRequiredProperty_Test()
        {
            var test = @"using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;

            namespace Analyzer1.Test.Entities
            {
                [DataContract]
                public class Class1
                {
                    string ID { get; set; }

                    public string Name { get; set; }
                }
            }
            ";

            var expected = new DiagnosticResult
            {
                Id = "Analyzer",
                Severity = DiagnosticSeverity.Warning,
                Message = String.Format("Property '{0}' should have the 'public' modificator", "ID"),
                Locations =
                    new[] {
                                new DiagnosticResultLocation("Test0.cs", 12, 21)
                        }
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        [TestMethod]
        public void NoDiagnostics_Test()
        {
            var test = @"using System;
            using System.Collections.Generic;
            using System.Linq;
            using System.Text;
            using System.Threading.Tasks;

            namespace Analyzer1.Test
            {
                class Class1
                {
                    string ID { get; set; }
                }
            }
            ";

            VerifyCSharpDiagnostic(test);
        }
    }
}