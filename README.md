使用方法
=======

### 引用命名空间
```
using Pingpp.Lib;
```

### Charge

* 创建账单
```
	var pingpp = new Pingpp(KEY);
	Error error;
	var charge = pingpp.CreateCharge(new ChargeCreateParam()
	{
	    OrderNo = "[商户订单号]",
	    App = new Dictionary<string, string>() { { "id", "[APPID]" } }, // App ID
	    Channel = "alipay", // 渠道
	    Amount = 10000000, // 金额
	    ClientIp = "127.0.0.1", // 客户端 IP
	    Currency = "cny", // ISO 货币代码
	    Subject = "[标题]",
	    Body = "[内容]",
	    Metadata = new Dictionary<string, string>() { { "[自定义数据名]", "[自定义数据值]" } },
	    // 其他参数
	}, out error);
```
* 查询账单详情
```
    var pingpp = new Pingpp(KEY);
    Error error;
    var charges = pingpp.ListCharge(new ChargeListParam()
    {
		// 查询参数
    }, out error);
```
* 查询账单列表
```
    var pingpp = new Pingpp(KEY);
    Error error;
    var charge = pingpp.RetrieveCharge(new ChargeRetrieveParam()
    {
        Id = "[Charge ID]"
    }, out error);
```

### Refund

* 创建退款
```
    var pingpp = new Pingpp(KEY);
    Error error;
    var refund = pingpp.CreateRefund(new RefundCreateParam()
    {
        Id = "[Charge ID]",
        Amount = 2, // 金额
        Description = "[描述]",
    }, out error);
```
* 查询退款详情
```
    var pingpp = new Pingpp(KEY);
    Error error;
    var refunds = pingpp.ListRefund(new RefundListParam()
    {
        Id = "[Charge ID]",
    }, out error);
```
* 查询退款列表
```
    var pingpp = new Pingpp(KEY);
    Error error;
    var refund = pingpp.RetrieveRefund(new RefundRetrieveParam()
    {
        Id = "[Charge ID]",
    }, out error);
```