// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

function passcodeHandler(){
    let element = document.getElementById("passcode");
    let session = document.getElementById("num");
    let url = window.location.href + "passcode";
    fetch(url)
        .then(res => {
            return res.json()
        })
        .then(res => {
            element.setAttribute("placeholder", res.passcode);
            session.innerText = parseInt(session.innerText) + 1;
        })
        .catch(err => console.log(err));
}
