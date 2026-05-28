let scriptsLoaded = false;
let loadPromise = null;

function loadScript(src) {
    return new Promise((resolve, reject) => {
        const existing = document.querySelector('script[data-src="' + src + '"]');
        if (existing) {
            resolve();
            return;
        }
        const script = document.createElement('script');
        script.setAttribute('data-src', src);
        script.src = src;
        script.onload = resolve;
        script.onerror = () => reject(new Error('Failed to load script: ' + src));
        document.head.appendChild(script);
    });
}

async function ensureScripts() {
    if (scriptsLoaded) return;
    if (loadPromise) return loadPromise;

    loadPromise = (async () => {
        await loadScript('_content/DocxPreview.Blazor/jszip.min.js');
        await loadScript('_content/DocxPreview.Blazor/docx-preview.min.js');
        scriptsLoaded = true;
    })();

    await loadPromise;
}

export async function renderDocx(containerId, documentBytes, options) {
    await ensureScripts();

    const container = document.getElementById(containerId);
    if (!container) {
        throw new Error("Container element with id '" + containerId + "' not found");
    }

    container.innerHTML = '';

    await window.docx.renderAsync(documentBytes, container, null, options || {});
}

export async function dispose(containerId) {
    const container = document.getElementById(containerId);
    if (container) {
        container.innerHTML = '';
    }
}
