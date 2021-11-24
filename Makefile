
pack:
	cd Wolfberry.TelldusLive.Console && dotnet pack -p:PackageVersion=$(version) -c Release -o out