#!/bin/bash

main () {
    if [[ $# -lt 1 ]]; then
        print_usage
        exit 1
    fi

    if [[ -z "$ENTRYPOINT" ]]; then
        >&2 echo "Missing required environment variable: ENTRYPOINT"
        exit 1
    fi

    if [[ "$1" == "start-server" ]]; then
        shift
        dotnet "$ENTRYPOINT" "${@}"
        exit $?
    fi

    if [[ "$1" == "show-schema" ]]; then
        dotnet "$ENTRYPOINT" schema export
        exit $?
    fi
}

print_usage() {
    >&2 echo "Expected one positional argument of: start-server, show-schema"
}

main "${@}"
