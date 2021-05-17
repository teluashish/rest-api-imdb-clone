$(document).ready(function () {
    $("#genresOption").select2();
    $('#actorsOption').select2();
    $('#producersOption').select2();
    $.ajax({ url: "https://localhost:64536/producers", type: "GET", success: producerSuccess, error: producerError });
    $.ajax({ url: "https://localhost:64536/actors", type: "GET", success: actorSuccess, error: actorError });
    $.ajax({ url: "https://localhost:64536/genres", type: "GET", success: genreSuccess, error: genreError });
});
var producers = [];
var actors = [];
var genres = [];




function producerSuccess(response) {
    producers = response;
    let childs = [];
    producers.forEach(producer => {
        childs.push(`<option value="${producer.id}" >${producer.name}</option>`);
    });
    $('#producerOptions').empty()
    $("#producerOptions").html(childs.join(" "));


    console.log(childs);
}

function producerError(error) {
    console.log(error);
}

function actorSuccess(response) {
    actors = response;
    let childs = [];
    actors.forEach(actor => {
        childs.push(`<option value="${actor.id}">${actor.name}</option>`);
    });
    $('#actorOptions').empty()
    $("#actorOptions").html(childs.join(" "));
    console.log("Success");
}

function actorError(error) {
    console.log(error);
}

function genreSuccess(response) {
    genres = response;
    let childs = [];
    genres.forEach(genre => {
        childs.push(`<option value="${genre.id}">${genre.name}</option>`)
    });
    $('#genreOptions').empty()
    $("#genreOptions").html(childs.join(" "));

}

function genreError(error) {
    console.log(error);
}


function addMovie() {
    
        let movie = JSON.stringify(
            {
                "name": $("#movieName").val(),
                "year": (new Date($('#movieRelease').val())).getFullYear(),
                "plot": $("#moviePlot").val(),
                "coverImage": $("#movieImage").val(),
                "producerId":parseInt($("#editProducer").val(),10),
                "movieActorMappingString":$("#editActors").val().join(","),
                "movieGenreMappingString":$("#editGenres").val().join(","),
                // : $("#actorOptions").val().join(","),
                // : $("#genreOptions").val().join(",")
            });
        console.log(movie);
       
        $.ajax({
            url: "https://localhost:64536/movies",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: movie,
            success: function () {
                window.alert("success");
            },
            error: function (error) {
                window.alert("error");
                console.log(error);
            },
            async: false
        });
    

}






