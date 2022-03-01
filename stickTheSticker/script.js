
function getImage(e) {
fetch('https://api.giphy.com/v1/stickers/random?api_key=dd9LCJxysHO4ogfqBQmjVceYaW3N9fz1')
  .then(response => response.json())
  .then(response => {
      const body = document.querySelector('body');
      const newImage = document.createElement("img")
      newImage.src = response.data.images.original.url;
      newImage.style.position = "absolute"
      newImage.style.left = `${e.pageX-(response.data.images.original.width/2)}px`; 
      newImage.style.top =`${e.pageY-(response.data.images.original.height/2)}px`; 
      body.appendChild(newImage);
      console.log(e)
    });
}
const body = document.querySelector('body');
body.addEventListener("click", getImage);