const imgs = document.getElementById("linha");
const img = document.querySelectorAll("div.item");
let idx = 0;

function fotos(){

    idx++;

    if(idx > img.length - 1){
        idx = 0;
    }

    imgs.style.transform = 'translateX(${-idx * 500}px)';
}

setInterval(fotos,1800);