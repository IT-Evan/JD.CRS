(function () {
    $(function () {

        var _tenantService = abp.services.app.tenant;
        var _$modal = $('#TenantCreateModal');
        var _$form = _$modal.find('form');

        var _$dataTable = $('#dataTable');
        //Bind Add Button to CreateModal
        $.fn.dataTable.ext.buttons.alert = {
            className: 'buttons-alert',

            action: function (e, dt, node, config) {
                _$modal.modal('show'); //Show the CreateModal
            }
        };
        //Set DataTable
        $(document).ready(function () {
            _$dataTable.DataTable({
                aLengthMenu: [[10, 25, 50, -1], [10, 25, 50, "全部"]], //PageSize
                pagingType: "full_numbers", //Type
                scrollY: 470, //Scroll
                //dom: 'Blfrtip', //Layout
                dom: "<'row'<'col-sm-8'B><'col-sm-4'lf>>" + "<'row'<'col-sm-12'tr>>" + "<'row'<'col-sm-6'i><'col-sm-6'p>>", //Layout
                //Button
                //buttons:
                //[ 
                //'copy', //复制到剪贴板
                //'csv', //导出CSV
                //'excel', //导出Excel
                //'pdf', //导出PDF
                //'print' //打印
                //],
                //Button
                buttons:
                    [
                        {// 自定义按钮-Add
                            extend: 'alert',
                            text: '+'
                            //text: '<i class="material-icons">add</i>'
                        },
                        { //复制到剪贴板
                            extend: 'copy',
                            text: 'Copy'
                        },
                        { //导出CSV
                            extend: 'csv',
                            text: 'CSV',
                            bom: true
                        },
                        { //导出Excel
                            extend: 'excel',
                            text: 'Excel'
                        },
                        { //导出PDF
                            extend: 'pdf',
                            text: 'PDF'
                        },
                        { //打印
                            extend: 'print',
                            text: 'Print'
                            //text: '<i class="material-icons">print</i>'
                        }
                    ],
                oLanguage: { //Language
                    //"sUrl": "~/lib/dataTables/Language/zh-cn.json"
                    "sEmptyTable": "无数据",
                    "sInfo": "显示第 _START_ 至 _END_ 项记录，共 _TOTAL_ 项",
                    "sInfoEmpty": "显示第 0 至 0 项记录 / 共 0 项",
                    "sInfoFiltered": "(从 _MAX_ 条记录过滤)",
                    "sInfoPostFix": "",
                    "sThousands": ",",
                    "sLengthMenu": "_MENU_ 项/页",
                    "sLoadingRecords": "载入中...",
                    "sProcessing": "处理中...",
                    "sSearch": '<i class="material-icons">search</i>',
                    "sZeroRecords": "没找到匹配的记录",
                    "oPaginate": {
                        "sFirst": "|<",
                        "sPrevious": "<",
                        "sNext": ">",
                        "sLast": ">|"
                    },
                    "oAria": {
                        "sSortAscending": ": 升序排序",
                        "sSortDescending": ": 降序排序"
                    }
                    //defaultStyle: {
                    //    font: '微软雅黑'
                    //}
                }
            });
            //pdfMake.fonts = {
            //    Roboto: {
            //        normal: 'Roboto-Regular.ttf',
            //        bold: 'Roboto-Medium.ttf',
            //        italics: 'Roboto-Italic.ttf',
            //        bolditalics: 'Roboto-Italic.ttf'
            //    },
            //    微软雅黑: {
            //        normal: 'msyh.ttf',
            //        bold: 'msyh.ttf',
            //        italics: 'msyh.ttf',
            //        bolditalics: 'msyh.ttf',
            //    }
            //};
        });


        _$form.validate();

        $('#RefreshButton').click(function () {
            refreshTenantList();
        });

        $('.delete-tenant').click(function () {
            var tenantId = $(this).attr("data-tenant-id");
            var tenancyName = $(this).attr('data-tenancy-name');

            deleteTenant(tenantId, tenancyName);
        });

        $('.edit-tenant').click(function (e) {
            var tenantId = $(this).attr("data-tenant-id");

            e.preventDefault();
            $.ajax({
                url: abp.appPath + 'Tenants/EditTenantModal?tenantId=' + tenantId,
                type: 'POST',
                contentType: 'application/html',
                success: function (content) {
                    $('#TenantEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var tenant = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js

            abp.ui.setBusy(_$modal);
            _tenantService.create(tenant).done(function () {
                _$modal.modal('hide');
                location.reload(true); //reload page to see new tenant!
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshTenantList() {
            location.reload(true); //reload page to see new tenant!
        }

        function deleteTenant(tenantId, tenancyName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'CRS'), tenancyName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _tenantService.delete({
                            id: tenantId
                        }).done(function () {
                            refreshTenantList();
                        });
                    }
                }
            );
        }
    });
})();