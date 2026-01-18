import type { NitroFetchRequest, NitroFetchOptions } from 'nitropack'

export function useApi<T = unknown>(
  request: NitroFetchRequest,
  opts?: NitroFetchOptions<NitroFetchRequest>
) {
  const config = useRuntimeConfig();

  return $fetch<T>(request, {
    baseURL: config.public.apiBase,
    credentials: 'include',
    ...opts,
  });
}