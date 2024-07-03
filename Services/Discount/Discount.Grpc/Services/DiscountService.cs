using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Discount.Grpc.Protos;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService(DiscountContext dbContext, ILogger<DiscountService> logger)
        : Protos.DiscountService.DiscountServiceBase
    {
        public override async Task<CouponResponse> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext
                .Coupons
                .FirstOrDefaultAsync(x => x.ProductName == request.ProductName) ??
                         new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };

            logger.LogInformation("Discount is retrieved for ProductName : {productName}, Amount : {amount}", coupon.ProductName, coupon.Amount);

            var couponResponse = coupon.Adapt<CouponResponse>();
            return couponResponse;
        }

        public override async Task<CouponResponse> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Discount Request"));
            else if (await dbContext.Coupons.AnyAsync(x => x.ProductName == coupon.ProductName))
                throw new RpcException(new Status(StatusCode.AlreadyExists, $"Discount for {coupon.ProductName} already exists"));
            dbContext.Coupons.Add(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully created. ProductName : {productName}", coupon.ProductName);
            var couponResponse = coupon.Adapt<CouponResponse>();
            return couponResponse;
        }

        public override async Task<CouponResponse> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid Discount Request"));
            dbContext.Coupons.Update(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully updated. ProductName : {productName}", coupon.ProductName);
            var couponResponse = coupon.Adapt<CouponResponse>();
            return couponResponse;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(x => x.ProductName == request.ProductName);
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount for {request.ProductName} not found"));
            dbContext.Coupons.Remove(coupon);
            await dbContext.SaveChangesAsync();
            logger.LogInformation("Discount is successfully deleted. ProductName : {productName}", request.ProductName);
            return new DeleteDiscountResponse { Success = true };

        }
    }
}
