// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Append text to note dates
var noteDates = document.getElementsByClassName('note-date');
for (var n = 0; n < noteDates.length; n++) {
    noteDates[n].textContent = `Created on ${noteDates[n].textContent}`;
}