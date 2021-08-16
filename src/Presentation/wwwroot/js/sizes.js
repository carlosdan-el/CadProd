const sizes = [];
const size = [];

async function renderSizes(data = []) {
    let sizeElement = document.getElementById('size-list');
    let content = '';

    if(data.length > 0) {
        data.map((item) => {
            content += '<tr>';
            content += `<td><a class="p-2" href="/Sizes/Edit?id=${item.id}">${item.name}</td>`;
            content += `<td>${item.description}</td>`;
            content += `<td>${item.createdBy}</td>`;
            content += `<td>${item.createdAt}</td>`;
            content += `<td>${item.updatedBy}</td>`;
            content += `<td>${item.updatedAt}</td>`;
            content += '</tr>';
        });
    }

    if(sizeElement) {
        sizeElement.innerHTML = '';
        sizeElement.innerHTML = content;
    }
}

async function renderSizeData(id = '') {
    let result = await getSizeById(id);
    size.push(result);
}

function renderFormData() {
    let id = document.getElementById('size-id');
    let name = document.getElementById('size-name');
    let description = document.getElementById('size-description');

    id.value = size[0]?.id;
    name.value = size[0]?.name;
    description.value = size[0]?.description;
}

function search(value = '') {
    let filtedValues = sizes;
    value = value.toLowerCase();

    if(value.length > 0) {
        filtedValues = filtedValues.filter(item => {     
            if(item.name.toLowerCase().includes(value) ||
            item.description.toLowerCase().includes(value)) {
                return item;
            }
        });
    }

    renderSizes(filtedValues);
}

(document.onload = async () => {

    if(params.id) {
        let btnDelete = document.getElementById('btn-delete');
        btnDelete.addEventListener('click', async () => await deleteRecord(params.id, 'Sizes', 'OnDelete'));
        await renderSizeData(params.id);
        renderFormData();
    }

    let btnSearch = document.getElementById('btn-search');
    btnSearch.addEventListener('click', (e) => {
        e.preventDefault();

        let searchInput = document.getElementById('search-input');
        search(searchInput.value);
    });

    let results = await getSizesView();
    sizes.push(...results);
    await renderSizes(sizes);
})();