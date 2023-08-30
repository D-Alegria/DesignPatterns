namespace Bridge
{
    /// <summary>
    /// Abstraction
    /// </summary>
    public abstract class Menu
    {
        public readonly ICoupon _coupon;

        protected Menu(ICoupon coupon)
        {
            _coupon = coupon;
        }

        public abstract int CalculatePrice();
    }

    /// <summary>
    /// RefinedAbstraction
    /// </summary>
    public class VegetarianMenu : Menu
    {
        public VegetarianMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 20 - _coupon.CouponValue;
        }
    }

    /// <summary>
    /// RefinedAbstraction
    /// </summary>
    public class MeatBasedMenu : Menu
    {
        public MeatBasedMenu(ICoupon coupon) : base(coupon)
        {
        }

        public override int CalculatePrice()
        {
            return 30 - _coupon.CouponValue;
        }
    }

    /// <summary>
    /// Implementor
    /// </summary>
    public interface ICoupon
    {
        int CouponValue { get; }
    }

    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class NoCoupon : ICoupon
    {
        public int CouponValue { get => 0; }
    }


    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class OneCoupon : ICoupon
    {
        public int CouponValue { get => 1; }
    }

    /// <summary>
    /// ConcreteImplementor
    /// </summary>
    public class TwoCoupon : ICoupon
    {
        public int CouponValue { get => 2; }
    }
}