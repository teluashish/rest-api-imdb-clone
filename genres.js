const deleteGenre = (id) => {
    $.ajax({
        url: "https://localhost:64536/genres/" + id,
        type: "DELETE",
        success: function (data) {
            window.alert('genre deleted successfully');   //data = id // tom
        },
        error: error =>  window.alert(error.responseText)
    });
}


const addGenre = () =>  {
    var genre = JSON.stringify({ "name": $("#genreName").val() });
    $.ajax({
        url: "https://localhost:64536/genres",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: genre,
        success: function () {
            window.alert("Genre added successfully.");
            $('#addGenreClose').trigger("click");
            location.href="index.html";
        },
        error: error =>  window.alert(error.responseText),
        async: false
    });
}


const genreError = (error) => {
    window.alert('genre error: '+error.responseText);
}