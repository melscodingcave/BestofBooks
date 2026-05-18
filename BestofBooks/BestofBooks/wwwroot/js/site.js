// ── Active nav link highlight ─────────────────────────────────────────────
// Marks the current page's nav link with aria-current="page"
// CSS uses this to apply the active highlight style via .bob-link.active
document.querySelectorAll('.bob-link').forEach(link => {
    if (link.href === window.location.href) {
        link.setAttribute('aria-current', 'page');
        link.classList.add('active');
    }
});

// ── Admin permission toggles ──────────────────────────────────────────────
// Each function sends a PUT to the API when a checkbox changes.
// cb.disabled temporarily blocks double-clicks while the request is in flight.
// On error, the checkbox is reverted to its previous state.

function toggleViewOnly(cb, id) {
    const newValue = cb.checked;
    cb.disabled = true;
    fetch('/api/user/updateViewOnlyRights', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ BoBuser_id: id, is_ViewOnly: newValue })
    })
        .then(res => {
            if (!res.ok) throw new Error('Request failed');
            cb.disabled = false;
        })
        .catch(err => {
            console.error('toggleViewOnly error:', err);
            cb.checked = !newValue;
            cb.disabled = false;
        });
}

function toggleAddsEnabled(cb, id) {
    const newValue = cb.checked;
    cb.disabled = true;
    fetch('/api/user/updateAddRights', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ BoBuser_id: id, adds_enabled: newValue })
    })
        .then(res => {
            if (!res.ok) throw new Error('Request failed');
            cb.disabled = false;
        })
        .catch(err => {
            console.error('toggleAddsEnabled error:', err);
            cb.checked = !newValue;
            cb.disabled = false;
        });
}

function toggleEditsEnabled(cb, id) {
    const newValue = cb.checked;
    cb.disabled = true;
    fetch('/api/user/updateEditRights', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ BoBuser_id: id, edits_enabled: newValue })
    })
        .then(res => {
            if (!res.ok) throw new Error('Request failed');
            cb.disabled = false;
        })
        .catch(err => {
            console.error('toggleEditsEnabled error:', err);
            cb.checked = !newValue;
            cb.disabled = false;
        });
}

function toggleDeletesEnabled(cb, id) {
    const newValue = cb.checked;
    cb.disabled = true;
    fetch('/api/user/updateDeleteRights', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ BoBuser_id: id, deletes_enabled: newValue })
    })
        .then(res => {
            if (!res.ok) throw new Error('Request failed');
            cb.disabled = false;
        })
        .catch(err => {
            console.error('toggleDeletesEnabled error:', err);
            cb.checked = !newValue;
            cb.disabled = false;
        });
}

function toggleIsAdmin(cb, id) {
    const newValue = cb.checked;
    cb.disabled = true;
    fetch('/api/user/updateAdminRights', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ BoBuser_id: id, is_Admin: newValue })
    })
        .then(res => {
            if (!res.ok) throw new Error('Request failed');
            cb.disabled = false;
        })
        .catch(err => {
            console.error('toggleIsAdmin error:', err);
            cb.checked = !newValue;
            cb.disabled = false;
        });
}