// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable EmptyNamespace
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.6
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeneratePOCOFromDB
{

    // MailList
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.36.1.0")]
    public class MailListConfiguration : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<MailList>
    {
        public MailListConfiguration()
            : this("dbo")
        {
        }

        public MailListConfiguration(string schema)
        {
            Property(x => x.MailTo).IsOptional();
            Property(x => x.MailContent).IsOptional();
            Property(x => x.SendStatus).IsOptional();
            Property(x => x.UpdateTime).IsOptional();
        }
    }

}
// </auto-generated>
