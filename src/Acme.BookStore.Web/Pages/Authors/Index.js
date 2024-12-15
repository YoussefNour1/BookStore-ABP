$(function () {
    var l = abp.localization.getResource('BookStore');
    var createModal = new abp.ModalManager(abp.appPath + 'Authors/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Authors/EditModal');

    var dataTable = $('#AuthorsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.bookStore.authors.author.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('BookStore.Authors.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    confirmMessage: function (data) {
                                        return l('AuthorDeletionConfirmationMessage', data.record.name);
                                    },
                                    visible: abp.auth.isGranted('BookStore.Authors.Delete'),
                                    action: function (data) {
                                        acme.bookStore.authors.author
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('Name'),
                    data: "name"
                },
                {
                    title: l('Birth Date'),
                    data: "birthDate",
                    dataFormat: "date"
                },
                {
                    title: l('Bio'),
                    data: "shortBio"
                },
                {
                    title: l('CreationTime'), data: "creationTime",
                    dataFormat: "datetime"
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewAuthorButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
