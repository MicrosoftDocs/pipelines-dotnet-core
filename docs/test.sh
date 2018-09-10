# Test driver script to be used in a container
# See http://docs.microsoft.com/azure/devops/pipelines/languages/docker for more information
sleep 5
if curl web | grep -q 'ASP.NET Core '; then
  echo "Tests passed!"
  exit 0
else
  echo "Tests failed!"
  exit 1
fi

