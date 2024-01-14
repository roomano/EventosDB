// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//++++++++++++++  CAROUSEL EDIT  +++++++++++++++++++++
var homeCarousel = document.querySelector("#homeCarousel");
var hCarousel = new bootstrap.Carousel(homeCarousel, {
  interval: 2000,
  pause: "hover",
  touch: true,
});
