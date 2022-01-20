FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine

RUN dotnet --list-runtimes
RUN dotnet tool install -g tdlive

ARG arguments
ENV arguments_env=$arguments

RUN pwd

ENV PATH="${PATH}:/root/.dotnet/tools"

ENTRYPOINT [ "tdlive" ]
CMD ["-h"]