docker build -f WebApiTestDocker/Dockerfile -t onur-proj .
docker rm -f my-webapi
docker run --restart unless-stopped --name my-webapi --net tulip-net -d -p 5000:80 onur-proj
