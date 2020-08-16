Tutorial project that I followed from [YouTube](https://www.youtube.com/playlist?list=PLPV2KyIb3jR5QFsefuO2RlAgWEz6EvVi6) that I added enhancements to.

# Building
This project was done using Unity Engine version 2019.2.18f1 and is used to build.

Dockerfile currently expects a WebGL build of the project from the builds/WebGL directory.

It's required for the builds/WebGL to be created in the root directory of this repository.

Then build the image with: `docker build -t game-nginx .`

# Deploying
A manifest for deploying the above docker image is included in this repository under the manifests directory.

Deploy the built WebGL version of the game with: `kubectl create -f manifests/`
