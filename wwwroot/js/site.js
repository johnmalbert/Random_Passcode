// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function makeRequest(){
    $.ajax({
        url: "http://localhost:5000/new",
    })
    .done(function(data){
        $("#passcode").html(data.passcode);
        $("#times").html(data.times);
    })
}
$("button").click(function(){
    makeRequest();
})