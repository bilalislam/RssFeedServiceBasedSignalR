var global = {
    loadGrid: function (data) {
        var datasource = new kendo.data.DataSource({
            transport: {
                read: function (e) {
                    e.success(data);
                }
            },
            schema: {
                data: "Data",
                total: "Total",
                model: {
                    id: "Guid",
                    fields: {
                        Guid: { type: "number" },
                        Title: { editable: true, type: "string", validation: { required: true } },
                        Description: { editable: true, type: "string", validation: { required: true } },
                        Link: { editable: true, type: "string", validation: { required: true } },
                        Url: { editable: true, type: "string", validation: { required: true } }
                    }
                }
            },
            pageSize: 5,
            serverPaging: false,
            serverFiltering: false,
            serverSorting: false
        });

        $("#grid").kendoGrid({
            dataSource: datasource,
            pageable: {
                pageSizes: [5, 10]
            },
            sortable: true,
            scrollable: false,
            filterable: {
                extra: false,
                operators: {
                    string: {
                        contains: "Contains"
                    }
                }
            },
            columns: [
                {
                    title: "Title",
                    field: "Title",
                    width: 300
                },
                {
                    title: "Description",
                    field: "Description",
                    width: 500,
                    encoded: false
                },
                {
                    title: "Link",
                    field: "Link",
                    width: 100
                }
            ]
        });
    },
    post: function (url, data, func) {
        $.ajax({
            url: url,
            type: "POST",
            data: data,
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                if (func) {
                    func(result);
                }
            },
            fail: function () {
                global.popup("Error", "An error occured");
            }
        });
    },
    popup: function (title, message) {
        var kendoWindow = $("<div />").kendoWindow({
            title: title,
            resizable: false,
            modal: true
        });

        var template = kendo.template($("#info-confirmation").html());
        kendoWindow.data("kendoWindow")
                   .content(template({ message: message }))
                   .center().open();

        kendoWindow
            .find(".info-confirm")
            .click(function () {
                kendoWindow.data("kendoWindow").close();
            })
            .end();
    }
};
