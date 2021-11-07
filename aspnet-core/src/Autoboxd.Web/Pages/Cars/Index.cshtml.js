$(function () {
    var addToListButton = $("#addToList");

    addToListButton.on("click", function (event) {
        event.preventDefault();
        debugger;

        var listId = 'C3D683B1-00F8-5777-95B4-39FFF911CEED';
        var itemId = $("#itemId").text();

        autoboxd.lists.list.addItem(listId, itemId);
    });
});