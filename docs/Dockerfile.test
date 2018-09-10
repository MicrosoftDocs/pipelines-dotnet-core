# This Dockerfile is for a test container to demonstrate use of docker-compose with Azure Pipelines
# See http://docs.microsoft.com/azure/devops/pipelines/languages/docker for more information

FROM ubuntu:trusty
RUN apt-get update && apt-get install -yq curl && apt-get clean
WORKDIR /app
ADD docs/test.sh /app/test.sh
CMD ["bash", "test.sh"]
