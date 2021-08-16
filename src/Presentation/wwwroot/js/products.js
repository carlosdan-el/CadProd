const product = [];

async function renderCategories() {
    let categoryElement = document.getElementById('product-category');
    let data = await getCategories();

    if(data.length > 0) {
        data.forEach(item => {
            let option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.name;

            if(product[0]?.categoryId && product[0]?.categoryId == item.id) {
                option.selected = true;
            } 

            categoryElement.appendChild(option);
        });
    }

    categoryElement.addEventListener('change', () => renderTypes(categoryElement.value));
}

async function renderTypes(id = '') {
    let typeElement = document.getElementById('product-type');
    let results = await getTypes(id);

    if(results.length > 0) {

        results.forEach(item => {
            let option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.name;

            if(product[0]?.typeId && product[0]?.typeId == item.id) {
                option.selected = true;
            }

            if(typeElement) {
                typeElement.appendChild(option);
            }

        });
    } else {
        for(let i = 1; i < typeElement.children.length; i++) {
            typeElement.removeChild(typeElement.children[i]);
        }
    }
}

async function renderSizes() {
    let sizeElement = document.getElementById('product-size');
    let data = await getSizes();

    if(data.length > 0) {
        data.forEach(item => {
            let option = document.createElement('option');
            option.value = item.id;
            option.textContent = item.name;

            if(product[0]?.sizeId && product[0]?.sizeId == item.id) {
                option.selected = true;
            }

            if(sizeElement) {
                sizeElement.appendChild(option);
            }

        });
    }
}

async function renderProductData(id = '') {
    let result = await getProductsById(id);
    product.push(result);
}

async function renderFormData() {
    let id = document.getElementById('product-id');
    let name = document.getElementById('product-name');
    let price = document.getElementById('product-price');
    let tags = document.getElementById('product-tags');
    let image = document.getElementById('product-image');
    let imagePreview = document.getElementById('image-preview');
    let description = document.getElementById('product-description');

    await renderTypes();

    id.value = product[0]?.id;
    name.value = product[0]?.name;
    price.value = product[0]?.price.toFixed(2);
    tags.value = product[0]?.tags;
    image.file = product[0]?.imagePath;
    imagePreview.src = product[0]?.imagePath;
    description.value = product[0]?.description;
}

(document.onload = async () => {
    
    if(params.id && params.id.length > 0) {
        let btnDelete = document.getElementById('btn-delete');
        btnDelete.addEventListener('click', async () => await deleteRecord(params.id, 'Products', 'OnDelete'));
        await renderProductData(params.id);
        await renderFormData();
    }

    await renderCategories();
    await renderSizes();
})();