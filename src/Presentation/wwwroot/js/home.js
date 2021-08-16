const products = [];

function renderProducts(data = []) {
    let productsElement = document.getElementById('products-list');
    let content = '';

    if(data.length > 0) {
        data.map((item) => {
            content += '<li class="card product-item">';
            content += `<a class="p-2" href="/Products/Edit?id=${item.id}">`;
            content += `<img class="card-img-top" src="${item.imagePath}"/>`;
            content += '</a>';
            content += '<div class="card-body product-item-description">';
            content += `<a href="/Products/Edit?id=${item.id}"><h5>${item.name}</h5></a>`;
            content += `<p>${item.price.toFixed(2)}</p>`;
            content += '</div>';
            content += '</li>';
        });
    }

    if(productsElement) {
        productsElement.innerHTML = '';
        productsElement.innerHTML = content;
    }
}

function search(value = '') {
    let filtedValues = products;
    value = value.toLowerCase();

    if(value.length > 0) {
        filtedValues = filtedValues.filter(item => {     
            if(item.name.toLowerCase().includes(value) ||
            item.tags.toLowerCase().includes(value)) {
                return item;
            }
        });
    }

    renderProducts(filtedValues);
}

(document.onload = async () => {
    let btnSearch = document.getElementById('btn-search');
    btnSearch.addEventListener('click', (e) => {
        e.preventDefault();

        let searchInput = document.getElementById('search-input');
        search(searchInput.value);
    });
    let results = await getProducts();
    products.push(...results);
    renderProducts(products);
})();