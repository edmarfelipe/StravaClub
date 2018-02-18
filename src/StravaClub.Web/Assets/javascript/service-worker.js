const CACHE = 'stava-club-v1';

const PRECACHE_URLS = [
	'/',
	'/index.css',
	'/index.js',
	'/fonts/OpenSans-Regular.woff2',
	'/fonts/OpenSans-Regular.woff',
	'/fonts/OpenSans-Light.woff2',
	'/fonts/OpenSans-Light.woff2'
];

self.addEventListener('install', evt => {
	evt.waitUntil(precache());
});

self.addEventListener('fetch', evt => {
	evt.respondWith(fromCache(evt.request));
	evt.waitUntil(update(evt.request));
});

function precache() {
	return caches.open(CACHE).then(function (cache) {
		return cache.addAll(PRECACHE_URLS);
	});
}

function fromCache(request) {
	return caches.open(CACHE).then(function (cache) {
		return cache.match(request).then(function (matching) {
			return matching || Promise.reject('no-match');
		});
	});
}

function update(request) {
	return caches.open(CACHE).then(function (cache) {
		return fetch(request).then(function (response) {
			return cache.put(request, response);
		});
	});
}