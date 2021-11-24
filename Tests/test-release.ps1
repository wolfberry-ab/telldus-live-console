param(
  [Parameter(Position=0,mandatory=$true)]
  [string]$version
)

az storage blob download `
  --account-name sttellduscicd `
  --container-name artifacts `
  --file tdlive.$version.nupkg `
  --name tdlive.$version.nupkg `
  --sas-token "$env:AZ_DOWNLOAD_TOKEN"
