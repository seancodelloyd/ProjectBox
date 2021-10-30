$(function () {
    var l = abp.localization.getResource('Autoboxd');

    var dataTable = $('#ItemsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(autoboxd.items.item.getList),
            columnDefs: [
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('CreationTime'),
                    data: "creationTime",
                    render: function (data) {
                        return luxon
                            .DateTime
                            .fromISO(data, {
                                locale: abp.localization.currentCulture.name
                            }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                    }
                }
            ]
        })
    );

    var createModal = new abp.ModalManager(abp.appPath + 'Items/CreateModal');

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewItemButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});