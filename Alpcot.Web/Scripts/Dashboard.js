
$(document).ready(
    function () {
        console.log("document ready)");
        initTradesGrid();
        initOrdersGrid("buy");
        initOrdersGrid("sell");
        initStocksDropDown("sellOrderStocksDropDown");
        initStocksDropDown("buyOrderStocksDropDown");
        initExecuteOrderButton("buy");
        initExecuteOrderButton("sell");
        initOrderQuantity("buy");
        initOrderQuantity("sell");
        initOrderPrice("buy");
        initOrderPrice("sell");

    }
);


function initTradesGrid() {
    console.log("init trades grid");

    $("#tradesGrid").dxDataGrid(
        {
            dataSource: getTradesGridCustomStore(),
            columns: [
                {
                    dataField: "stockName"
                },
                {
                    dataField: "quantity"
                },
                {
                    dataField: "price"
                }
            ]
        }
    );
}

function getTradesGridCustomStore() {
    var store = new DevExpress.data.CustomStore({
        key: "Id",
        load: function (loadOptions) {
            var d = new $.Deferred();
            $.get("https://localhost:44361/api/Trades")
                .done(function (dataItem) {
                    d.resolve(dataItem);
                });
            return d.promise();
        }

    });

    return store;
}


function initOrdersGrid(action) {
    console.log("init trades grid");

    $("#" + action + "OrdersGrid").dxDataGrid(
        {
            dataSource: getOrdersCustomStore(action),
            columns: [
                {
                    caption: "Stock",
                    dataField: "stockName"
                },
                {
                    dataField: "quantity"

                },
                {
                    dataField: "price"
                },
                {
                    caption: "Date",
                    dataType: "date",
                    format: 'dd/MM/yyy hh:mm:ss',
                    width: "200px",
                    dataField: "datePlaced"
                }
            ]
        }
    );
}

function initStocksDropDown(id) {
    $("#" + id).dxSelectBox({
        dataSource: getStocksCustomStore(),
        placeholder: "Select a Stock",
        valueExpr: "id",
        displayExpr: "name"
    }).dxValidator({
        validationRules: [{
            type: "required",
            message: "Stock is required"
        }]
    });
}



function getOrdersCustomStore(action) {
    console.log("get orders");
    var store = new DevExpress.data.CustomStore({
        key: "Id",
        load: function (loadOptions) {
            var d = new $.Deferred();
            $.get("https://localhost:44361/api/Get" + action + "Orders")
                .done(function (dataItem) {

                    d.resolve(dataItem);
                });
            return d.promise();
        }

    });

    return store;
}

function getStocksCustomStore() {
    var store = new DevExpress.data.CustomStore({
        key: "Id",
        load: function (loadOptions) {
            var d = new $.Deferred();
            $.get("https://localhost:44361/api/GetStocks")
                .done(function (dataItem) {
                    d.resolve(dataItem);
                });
            return d.promise();
        }

    });

    return store;
}


function initOrderQuantity(action) {
    $("#" + action + "OrderQuantity").dxNumberBox({
        value: 10,
        showSpinButtons: true,
        showClearButton: true,
        min:1
    }).dxValidator({
        validationRules: [{
            type: "numeric",
            message: "Quantity must be numeric"
        }]
    });
}

function initOrderPrice(action) {
    $("#" + action + "OrderPrice").dxNumberBox({
        value: 1.00,
        showSpinButtons: true,
        showClearButton: true,
        min:0.1
    }).dxValidator({
        validationRules: [{
            type: "numeric",
            message: "Price must be numeric"
        }]
    });
}

function initExecuteOrderButton(orderAction) {
    $("#" + orderAction + "OrderExecute").dxButton({
        text: "Execute",
        width: 120,
        onClick: function () {
            var stockId = $("#" + orderAction + "OrderStocksDropDown").dxSelectBox('instance').option('value');
            var price = $("#" + orderAction + "OrderPrice").dxNumberBox("instance").option("value");
            var quantity = $("#" + orderAction + "OrderQuantity").dxNumberBox("instance").option("value");

            var priceControl = $("#" + orderAction + "OrderPrice").dxValidator("instance");
            var quantityControl = $("#" + orderAction + "OrderQuantity").dxValidator("instance");
            var stockControl = $("#" + orderAction + "OrderStocksDropDown").dxValidator("instance");
            if (priceControl.validate().isValid && quantityControl.validate().isValid && stockControl.validate().isValid) {
                executeOrder(orderAction, stockId, quantity, price);
            } else {
                DevExpress.ui.notify("Please correct errrors");

            }
        }
    });
}

function executeOrder(action, stockId, quantity, price) {


    jQuery.ajax({
        url: "https://localhost:44361/api/Create" + action + "Order",
        type: 'POST',
        contentType: "text/json",
        data: JSON.stringify({ stockId: stockId, quantity: quantity, price: price }),
        success: function () {
            initTradesGrid();
            initOrdersGrid("buy");
            initOrdersGrid("sell");
            DevExpress.ui.notify("Order Placed");

        },
        error: function() {
            DevExpress.ui.notify("An unhandled error occurred. Please contact your administrator.");

        }
    });

}