using XCRS.Services.TargetService.Domain.Entities;

namespace XCRS.Services.TargetService.Application.UseCases.Queries.Types
{
    //public class TargetType : ObjectGraphType<Target>
    //{
    //    public TargetType()
    //    {
    //        try
    //        {
    //            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the Target object.");
    //            Field(x => x.Code).Description("Code property from the Target object.");
    //            Field<NonNullGraphType<TargetBiType>>(nameof(TargetBi))
    //              .Description("TargetBi property from the Target object.")
    //              .Resolve(context => context.Source!.TargetBi);
    //            Field<NonNullGraphType<TargetResourceType>>(nameof(TargetResource))
    //              .Description("TargetResource property from the Target object.")
    //              .Resolve(context => context.Source!.TargetResource);
    //        }
    //        catch (Exception ex)
    //        {
    //            throw;
    //        }
    //    }

    //    public class TargetBiType : ObjectGraphType<TargetBi>
    //    {
    //        public TargetBiType()
    //        {
    //            Field(x => x.NameEn, type: typeof(IdGraphType)).Description("NameEn property from the TargetBi object.");
    //            Field(x => x.NameKo, type: typeof(IdGraphType)).Description("NameKo property from the TargetBi object.");
    //            Field(x => x.Domain, type: typeof(IdGraphType)).Description("Domain property from the TargetBi object.");
    //            Field(x => x.PhoneNo, type: typeof(IdGraphType)).Description("PhoneNo property from the TargetBi object.");
    //            Field(x => x.Address, type: typeof(IdGraphType)).Description("Address property from the TargetBi object.");
    //            Field(x => x.Ceo, type: typeof(IdGraphType)).Description("Ceo property from the TargetBi object.");
    //            Field(x => x.Email, type: typeof(IdGraphType)).Description("Email property from the TargetBi object.");
    //        }
    //    }

    //    public class TargetResourceType : ObjectGraphType<TargetResource>
    //    {
    //        public TargetResourceType()
    //        {
    //            Field(x => x.LoginBannerUrl, type: typeof(IdGraphType)).Description("LoginBannerUrl property from the TargetResource object.");
    //            Field(x => x.GnbBannerUrl, type: typeof(IdGraphType)).Description("GnbBannerUrl property from the TargetResource object.");
    //            Field(x => x.ColorSetCode, type: typeof(IdGraphType)).Description("ColorSetCode property from the TargetResource object.");
    //        }
    //    }
    //}
}