import html
import logging
import os
import yaml
from global_state import global_state
logger = logging.getLogger("mkdocs")
def on_nav(nav, config, files):
    _fix_nav_titles(nav.items, config)
    global_state["nav_tree"] = nav.items
    logger.log(logging.INFO, "Captured navigation tree.")

def on_page_context(context, page, config, nav):
    if page.title and ('<' in page.title or '>' in page.title):
        page.title = html.escape(page.title)

def _fix_nav_titles(items, config):
    docs_dir = config['docs_dir']
    for item in items:
        if item.is_section:
            for child in item.children:
                if child.is_page and child.file.name == 'index':
                    title = _read_front_matter_title(os.path.join(docs_dir, child.file.src_path))
                    if title:
                        item.title = html.escape(title)
                    break
            if item.children:
                _fix_nav_titles(item.children, config)
        elif item.is_page:
            title = _read_front_matter_title(os.path.join(docs_dir, item.file.src_path))
            if title:
                item.title = html.escape(title)

def _read_front_matter_title(path):
    try:
        with open(path, 'r') as f:
            content = f.read()
        if content.startswith('---'):
            end = content.index('---', 3)
            front_matter = yaml.safe_load(content[3:end])
            if isinstance(front_matter, dict):
                return front_matter.get('title')
    except Exception:
        pass
    return None
