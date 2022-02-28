
function getImage() {
fetch('https://api.giphy.com/v1/stickers/random?api_key=dd9LCJxysHO4ogfqBQmjVceYaW3N9fz1')
  .then(response => response.json())
  .then(response => {
      const image = document.querySelector("img");
      image.src = response.data.images.original.url;
    });
}

  const body = document.querySelector('body');
  body.addEventListener("click", getImage);